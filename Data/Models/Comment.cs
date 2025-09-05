using Newtonsoft.Json;

namespace Data.Models;

public class CommentsResponse
{
    [JsonProperty("result")]
    public List<Comment> Result { get; set; } = null!;
    
    [JsonIgnore]
    public int Time { get; set; }
}

public class Comment
{
    [JsonProperty("POST_MESSAGE_HTML")]
    public string? PostMessageHtml { get; set; }

    [JsonProperty("ID")]
    public int Id { get; set; }

    [JsonProperty("AUTHOR_ID")]
    public string AuthorId { get; set; } = null!;

    [JsonProperty("AUTHOR_NAME")]
    public string AuthorName { get; set; } = null!;

    [JsonProperty("AUTHOR_EMAIL")]
    public string AuthorEmail { get; set; } = null!;

    [JsonProperty("POST_DATE")]
    public DateTime PostDate { get; set; }

    [JsonProperty("POST_MESSAGE")] 
    public string PostMessage { get; set; } = null!;
    
    [JsonProperty("ATTACHED_OBJECTS")]
    public Dictionary<string, AttachedObject>? AttachedObjects { get; set; }
}