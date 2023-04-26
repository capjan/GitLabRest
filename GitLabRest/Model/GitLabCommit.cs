using System.Text.Json.Serialization;

namespace GitLabRest.Model;

public class GitLabCommit
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    
    [JsonPropertyName("short_id")]
    public string? ShortId { get; set; }
    
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }
    
    [JsonPropertyName("parent_ids")]
    public string[]? ParentIds { get; set; }
    
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    
    [JsonPropertyName("author_name")]
    public string? AuthorName { get; set; }
    
    [JsonPropertyName("author_email")]
    public string? AuthorEmail { get; set; }
    
    [JsonPropertyName("authored_date")]
    public string? AuthoredDate { get; set; }
    
    [JsonPropertyName("committer_name")]
    public string? CommitterName { get; set; }
    
    [JsonPropertyName("committer_email")]
    public string? CommitterEmail { get; set; }
    
    [JsonPropertyName("committer_date")]
    public string? CommitterDate { get; set; }
    
    [JsonPropertyName("web_url")]
    public string? WebUrl { get; set; }
    
}