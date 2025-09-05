using Business.Interfaces;
using Data.Interfaces;

namespace Business;

public class Exporter: IExporter
{
    private readonly IHttpService _httpService;
    public Exporter(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task StartExport(string webHook, string exportPath)
    {
        var t = await _httpService.GetFileAsync("https://atlant.bitrix24.by/bitrix/tools/disk/uf.php?attachedId=131&auth%5Baplogin%5D=105&auth%5Bap%5D=5xb1kzirjpnm5bcx&action=download&ncc=1");
    }
}