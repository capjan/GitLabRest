
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global

using System.Text.Json.Serialization;


namespace GitLabRest.Model;

public class GitLabProject
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("web_url")]
    public string? WebUrl { get; set; }

    public override string ToString()
    {
        return $"{Name} (Id: {Id})";
    }
}