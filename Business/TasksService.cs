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
        foreach (var task in tasks)
        {
            var comments = await _http.GetCommentsAsync(task.Id);
            task.Comments.AddRange(comments);
        }
        return tasks;
    }

    //todo test
    public List<BitrixTask> GetHierarchyList(List<BitrixTask> tasks)
    {
        var subtasks = FindAllSubtasks(tasks);
        var hierarchy = new List<BitrixTask>();
        foreach (var task in tasks)
        {
            var taskChildren = subtasks[task.Id];
            task.ChildTasks.AddRange(taskChildren);

            if (task.ParentId is null or 0)
            {
                hierarchy.Add(task);
            }
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