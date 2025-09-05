using Newtonsoft.Json;

namespace Data.Models;

public class AttachedObject
{
    [JsonProperty("ATTACHMENT_ID")]
    public string AttachmentId { get; set; } = null!;

    [JsonProperty("NAME")]
    public string Name { get; set; } = null!;

    [JsonProperty("SIZE")]
    public string Size { get; set; } = null!;

    [JsonProperty("FILE_ID")]
    public string FileId { get; set; } = null!;

    [JsonProperty("DOWNLOAD_URL")]
    public string DownloadUrl { get; set; } = null!;

    [JsonProperty("VIEW_URL")]
    public string ViewUrl { get; set; } = null!;
}

public class BitrixFileInfo
{
    public string Name { get; set; } = null!;
    public Stream Stream { get; set; } = null!;
}