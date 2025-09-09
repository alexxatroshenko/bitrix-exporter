using System.Collections;
using System.Diagnostics;
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
    
    #region TestData
    public static IEnumerable<object[]> TestDataForGetHierarchyList()
    {
        //Задачи без подзадач
        var random = new Random();
        var flatTasks = Enumerable.Range(1, 5)
            .Select(i => new BitrixTask { Id = i, ParentId = random.Next(2) == 0 ? 0 : null }).ToList();
        yield return [flatTasks];
        
        //У задач есть подзадачи
        var tasksWithSubtasks1 = new List<BitrixTask>
        {
            new() { Id = 1, ParentId = 0 },
            new() { Id = 2, ParentId = 1 },
            new() { Id = 3, ParentId = 1 },
            new() { Id = 4, ParentId = 2 },
            new() { Id = 5, ParentId = 0 },
            new() { Id = 6, ParentId = 5 },
            new() { Id = 7, ParentId = 5 },
            new() { Id = 8, ParentId = 5 },
        };
        yield return [tasksWithSubtasks1];
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
    #endregion
    
    [Fact]
    public async Task GetTasksAsync_WhenHttpServiceReturnTasks_ReturnSameTasks()
    {
        var expectedTasks = _tasks;

        _httpServiceMock.Setup(service => service.GetTasksAsync()).ReturnsAsync(expectedTasks);

        var result = await _tasksService.GetTasksAsync();

        result.Should().NotBeNullOrEmpty().And.HaveCount(2).And.BeEquivalentTo(expectedTasks);
        
        _httpServiceMock.Verify(service => service.GetTasksAsync(), Times.Once);
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
    
    [Theory]
    [MemberData(nameof(TestDataForGetHierarchyList))]
    public void GetHierarchyList_ShouldBuildCorrectHierarchy(List<BitrixTask> inputTasks)
    {
        var hierarchy = _tasksService.GetHierarchyList(inputTasks);
        var rootTasks = inputTasks.Where(x => x.ParentId is null or 0).ToList();
        
        hierarchy.Should().HaveCount(rootTasks.Count);

        AssertHierarchy(rootTasks, inputTasks);
    }
    
    private static void AssertHierarchy(List<BitrixTask> tasks, List<BitrixTask> inputTasks)
    {
        foreach (var task in tasks)
        {
            task.ChildTasks
                .Should()
                .HaveCount(inputTasks.Count(x => x.ParentId == task.Id));
            
            Debug.WriteLine($"task {task.Id}");
            
            if (task.ChildTasks.Count != 0)
            {
                AssertHierarchy(task.ChildTasks, inputTasks);
            }
        }
    }
}