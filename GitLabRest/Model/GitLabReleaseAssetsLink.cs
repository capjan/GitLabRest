using System.Text.Json.Serialization;

namespace GitLabRest.Model;

public class GitLabReleaseAssetsLink
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}