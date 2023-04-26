using System.Text.Json.Serialization;

namespace GitLabRest.Model;

public class GitLabAuthor
{
    
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    
    [JsonPropertyName("username")]
    public string? UserName { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("state")]
    public string? State { get; set; }
    
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; set; }
    
    [JsonPropertyName("web_url")]
    public string? WebUrl { get; set; }
}