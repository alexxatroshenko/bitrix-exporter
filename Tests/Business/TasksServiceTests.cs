using System.Collections;
using Business;
using Business.Interfaces;
using Data.Interfaces;
using Data.Models;
using FluentAssertions;
using Moq;

namespace Tests.Business;

public class TasksServiceTests
{
    private readonly Mock<IHttpService> _httpServiceMock;
    private readonly TasksService _tasksService;
    private List<BitrixTask> _tasks =
    [
        new() { Id = 1, ParentId = null, Title = "Task 1" },
        new() { Id = 2, ParentId = 1, Title = "subtask 1" }
    ];

    public TasksServiceTests()
    {
        _httpServiceMock = new Mock<IHttpService>();
        _tasksService = new TasksService(_httpServiceMock.Object);
    }

    [Fact]
    public async Task GetTasksAsync_WhenHttpServiceReturnTasks_ReturnSameTasks()
    {
        var expectedTasks = _tasks;

        _httpServiceMock.Setup(service => service.GetTasksAsync()).ReturnsAsync(expectedTasks);

        var result = await _tasksService.GetTasksAsync();

        result.Should().NotBeNullOrEmpty().And.HaveCount(2).And.BeEquivalentTo(expectedTasks);
        
        _httpServiceMock.Verify(service => service.GetTasksAsync(), Times.Once);
    }

    public static IEnumerable<object[]> TestDataForGetComments()
    {
        //Первая и последняя задача имеют комментарии
        yield return
        [
            Enumerable.Range(1, 4).Select(i => new BitrixTask { Id = i, Title = $"title {i}" }).ToList(),
            new List<List<Comment>>
            {
                new() { new Comment{ Id = 1 }, new Comment{ Id = 2 }},
                new(),
                new(),
                new() { new Comment{ Id = 3 }, new Comment{ Id = 4 }}
            }
        ];
        
        //Задачи не имеют комментариев
        yield return  [Enumerable.Range(1, 10).Select(i => new BitrixTask { Id = i, Title = $"title {i}" }).ToList(), new List<List<Comment>>()];
        
        //Каждая задача имеет 1 комментарий
        var tasks = Enumerable.Range(1, 10).Select(i => new BitrixTask { Id = i, Title = $"title {i}" }).ToList();
        var comments = Enumerable.Range(1, 10).Select(i => new List<Comment> { new() {Id = i, PostMessage = $"message {i}"}}).ToList();
        yield return [tasks, comments];
    }
    
    [Theory]
    [MemberData(nameof(TestDataForGetComments))]
    public async Task GetCommentsAsync_ShouldReturnCorrectData(List<BitrixTask> inputTasks, List<List<Comment>> serviceCommentsOutput)
    {
        for (var i = 0; i < inputTasks.Count; i++)
        {
            _httpServiceMock.Setup(service => service.GetCommentsAsync(inputTasks[i].Id)).ReturnsAsync(serviceCommentsOutput.Count > i ? serviceCommentsOutput[i] : []);
        }

        var result = await _tasksService.AttachCommentsToTasksAsync(inputTasks);

        result.Should().NotBeNullOrEmpty();
        result.Should().HaveCount(inputTasks.Count);
        for (var i = 0; i < inputTasks.Count; i++)
        {
            result[i].Comments.Should().HaveCount(serviceCommentsOutput.Count > i ? serviceCommentsOutput[i].Count : 0).And
                .BeEquivalentTo(serviceCommentsOutput.Count > i ? serviceCommentsOutput[i] : []);
        }
    }
}