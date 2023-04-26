using System.Text.Json.Serialization;

namespace GitLabRest.Model;

public class GitLabReleaseAssets
{
    [JsonPropertyName("count")]
    public int? Count { get; set; }
    
    [JsonPropertyName("sources")]
    public GitLabReleaseSource[]? Sources { get; set; }
    
    [JsonPropertyName("links")]
    public GitLabReleaseAssetsLink[]? Links { get; set; }
}