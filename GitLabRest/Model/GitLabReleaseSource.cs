using System.Text.Json.Serialization;

namespace GitLabRest.Model;

public class GitLabReleaseSource
{
    [JsonPropertyName("format")]
    public string? Format { get; set; }
    
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}