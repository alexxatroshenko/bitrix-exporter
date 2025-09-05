using Data.Models;

namespace Data.Interfaces;

public interface IHttpService
{
    void ConfigureHttpClient(string webhook);
    Task<List<BitrixTask>> GetTasksAsync();
    Task<List<Comment>> GetCommentsAsync(int taskId);
    Task<Stream> GetFileAsync(string url);
}