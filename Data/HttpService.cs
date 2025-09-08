using System.Text;
using Data.Interfaces;
using Data.Models;
using Newtonsoft.Json;

namespace Data;

public class HttpService(HttpClient http) : IHttpService
{
    public void ConfigureHttpClient(string webhook)
    {
        http.BaseAddress ??= new Uri(webhook);
    }

    public async Task<List<BitrixTask>> GetTasksAsync()
    {
        var httpResponse = await http.GetAsync("task.ctasks.getlist.json");
        
        return await ResponseConverter.ToNeededResponse<TasksResponse, BitrixTask>(httpResponse);
    }

    public async Task<List<Comment>> GetCommentsAsync(int taskId)
    {
        var body = JsonConvert.SerializeObject(new{TaskId = taskId});
        var httpResponse = await http.PostAsync("task.commentitem.getlist.json",
            new StringContent(body, Encoding.UTF8, "application/json"));
        
        return await ResponseConverter.ToNeededResponse<CommentsResponse, Comment>(httpResponse);
    }

    public async Task<Stream> GetFileAsync(string url)
    {
        var getResponse = await http.GetAsync(url);
        var content = await getResponse.Content.ReadAsByteArrayAsync();
        return new MemoryStream(content);
    }
}