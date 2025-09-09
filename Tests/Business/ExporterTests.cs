using System.Collections;
using Business;
using Business.Interfaces;
using Data.Interfaces;
using Data.Models;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;

namespace Tests.Business;

// Примечание: Для более точного тестирования метода SaveDataToPath, который является приватным,
// рекомендуется:
// 1. Сделать метод SaveDataToPath виртуальным в классе Exporter
// 2. Или использовать интерфейс для файловой системы и внедрить его как зависимость
// 3. Или создать отдельный метод SaveDataToPath в интерфейсе IExporter для тестирования

public class ExporterTests
{
    private readonly Mock<IHttpService> _httpServiceMock;
    private readonly Mock<ITasksService> _tasksServiceMock;
    private readonly Exporter _exporter;
    private const string Webhook = "https://atlant.by/";
    private const string ExportPath = "test-exportPath";
    
    private readonly List<BitrixTask> _expectedTasks =
    [
        new BitrixTask
        {
            Id = 1,
            ParentId = null,
            Title = "Task 1",
            Comments = [
                // new Comment
                // {
                //     Id = 1, 
                //     AttachedObjects = new Dictionary<string, AttachedObject>{ {"13", new AttachedObject()} }
                // }
            ]
        },

        new BitrixTask
        {
            Id = 2,
            ParentId = 1,
            Title = "subtask 1",
            Comments = [
                // new Comment
                // {
                //     Id = 1, 
                //     AttachedObjects = new Dictionary<string, AttachedObject>{ { "13", new AttachedObject{ Name = "test" } } }
                // }
            ]
        }
    ];
    
    private readonly List<BitrixTask> _expectedTasksTree =
    [
        new()
        {
            Id = 1,
            ParentId = null,
            Title = "Task 1",
            Comments = [
                // new Comment
                // {
                //     Id = 1, 
                //     AttachedObjects = new Dictionary<string, AttachedObject>{ { "13", new AttachedObject{ Name = "test" } } }
                // }
            ],
            ChildTasks =
            [
                new BitrixTask()
                {
                    Id = 2,
                    ParentId = 1,
                    Title = "subtask 1",
                    Comments = [
                        // new Comment
                        // {
                        //     Id = 1, 
                        //     AttachedObjects = new Dictionary<string, AttachedObject>{ { "13", new AttachedObject{ Name = "test" } } }
                        // }
                    ]
                }
            ]
        }
    ];

    public ExporterTests()
    {
        _httpServiceMock = new Mock<IHttpService>();
        _tasksServiceMock = new Mock<ITasksService>();
        _exporter = new Exporter(_httpServiceMock.Object, _tasksServiceMock.Object);
        
        _tasksServiceMock.Setup(x => x.GetTasksAsync()).ReturnsAsync(_expectedTasks);
        _tasksServiceMock.Setup(x => x.AttachCommentsToTasksAsync(It.IsAny<List<BitrixTask>>())).ReturnsAsync(_expectedTasks);
        _tasksServiceMock.Setup(x => x.GetHierarchyList(It.IsAny<List<BitrixTask>>())).Returns(_expectedTasksTree);
    }

    [Fact]
    public async Task Exporter_ShouldInvokeAllStatusEvents()
    {
        var statusMessages = new List<string>();
        
        _exporter.OnStatusChanged += message => statusMessages.Add(message);
        await _exporter.StartExport(Webhook, ExportPath);

        statusMessages.Should().HaveCount(4);
        statusMessages[0].Should().Be("Получение задач...");
        statusMessages[1].Should().Be("Получение комментариев...");
        statusMessages[2].Should().Be("Формирование иерархии задач...");
        statusMessages[3].Should().Be("Сохранение данных...");
    }

    [Fact]
    public async Task Exporter_ShouldSaveAllAttachedFiles()
    {
        _httpServiceMock.Setup(service => service.GetFileAsync(It.IsAny<string>())).ReturnsAsync(Stream.Null);
        await _exporter.StartExport(Webhook, ExportPath);
        var totalAttachedObjects = _expectedTasks
            .Where(x => x.Comments.Count != 0)
            .SelectMany(y => y.Comments)
            .SelectMany(comment => comment.AttachedObjects?.Values ?? Enumerable.Empty<AttachedObject>())
            .Count();
        _httpServiceMock.Verify(service => service.GetFileAsync(It.IsAny<string>()), Times.Exactly(totalAttachedObjects));
    }
}