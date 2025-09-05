namespace Business.Interfaces;

public interface IExporter
{
    Task StartExport(string webHook, string exportPath);
}