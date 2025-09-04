namespace Business.Interfaces;

public interface IExporter
{
    void StartExport(string webHook, string exportPath);
}