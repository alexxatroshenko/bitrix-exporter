using Data.Models;

namespace Business.Interfaces;

public interface ITasksService
{
    Task<List<BitrixTask>> GetTasksAsync();
    Task<List<BitrixTask>> AttachCommentsToTasksAsync(List<BitrixTask> tasks);
    List<BitrixTask> GetHierarchyList(List<BitrixTask> tasks);
}