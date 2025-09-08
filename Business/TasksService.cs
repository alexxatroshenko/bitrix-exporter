using Business.Interfaces;
using Data.Interfaces;
using Data.Models;

namespace Business;

public class TasksService: ITasksService
{
    private readonly IHttpService _http;

    public TasksService(IHttpService http)
    {
        _http = http;
    }

    public async Task<List<BitrixTask>> GetTasksAsync()
    {
        return await _http.GetTasksAsync();
    }

    public async Task<List<BitrixTask>> AttachCommentsToTasksAsync(List<BitrixTask> tasks)
    {
        var asyncTasks = tasks.Select(async task =>
        {
            var comments = await _http.GetCommentsAsync(task.Id);
            task.Comments.AddRange(comments);
        });
        await Task.WhenAll(asyncTasks);
        
        return tasks;
    }

    public List<BitrixTask> GetHierarchyList(List<BitrixTask> tasks)
    {
        var subtasks = FindAllSubtasks(tasks);
        var hierarchy = new List<BitrixTask>();
        foreach (var task in tasks)
        {
            if (task.ParentId is null or 0)
            {
                hierarchy.Add(task);
            }
            
            if(!subtasks.TryGetValue(task.Id, out var childTasks)) continue;
            task.ChildTasks.AddRange(childTasks);
        }

        return hierarchy;
    }

    private Dictionary<int, IEnumerable<BitrixTask>> FindAllSubtasks(List<BitrixTask> tasks)
    {
        return tasks
            .Where(x => x.ParentId is not null)
            .GroupBy(x => x.ParentId)
            .ToDictionary(x => (int)x.Key!, x => x.AsEnumerable());
    }
}