using Business.Interfaces;
using Data.Interfaces;
using Data.Models;
using Newtonsoft.Json;

namespace Business;

public class Exporter(IHttpService httpService, ITasksService tasksService) : IExporter
{
    public event Action<string>? OnStatusChanged;
    public async Task StartExport(string webHook, string exportPath)
    {
        OnStatusChanged?.Invoke("Получение задач...");
        var tasks = await tasksService.GetTasksAsync();
        
        OnStatusChanged?.Invoke("Получение комментариев...");
        tasks = await tasksService.AttachCommentsToTasksAsync(tasks);
        
        OnStatusChanged?.Invoke("Формирование иерархии задач...");
        var tasksTree = tasksService.GetHierarchyList(tasks);
        
        OnStatusChanged?.Invoke("Сохранение данных...");
        await SaveDataToPath(exportPath + @"\bitrix_export\", tasksTree, webHook);
    }

    private async Task SaveDataToPath(string path, List<BitrixTask> tasksTree, string webhook)
    {
        foreach (var task in tasksTree)
        {
            var taskDirectoryName = @$"task_{task.Id}";
            var endpoint = Path.Combine(path, taskDirectoryName);
            var fullJsonPath = Path.Combine(endpoint, taskDirectoryName + ".json");
            if (!Directory.Exists(endpoint))
            {
                Directory.CreateDirectory(endpoint);
            }

            var jsonTask = JsonConvert.SerializeObject(task, Formatting.Indented);
            await File.WriteAllTextAsync(fullJsonPath, jsonTask);

            if (task.Comments.Any(x => x.AttachedObjects is not null))
            {
                await SaveAttachedFiles(task, webhook, endpoint);
            }
            
            if (task.ChildTasks.Any())
            {
                await SaveDataToPath(endpoint, task.ChildTasks, webhook);
            }
        }
    }

    private async Task SaveAttachedFiles(BitrixTask task, string webhook, string endpoint)
    {
        var attachedObjects = task.Comments
            .Where(x => x.AttachedObjects is not null)
            .Select(x => x.AttachedObjects);
        foreach (var item in attachedObjects)
        {
            var objList = item?.Values.ToList();
            if (objList == null) continue;
                    
            foreach (var obj in objList)
            {
                var webhookUri = new Uri(webhook);
                var baseUrl = webhookUri.GetLeftPart(UriPartial.Authority);

                await using var stream = await httpService.GetFileAsync(baseUrl + obj.DownloadUrl);
                
                var invalidChars = Path.GetInvalidFileNameChars();
                var cleanFileName = string.Join("_", obj.Name.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries));

                await using var fileStream = new FileStream(Path.Combine(endpoint, cleanFileName), FileMode.Create,
                    FileAccess.Write);
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}