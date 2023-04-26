using System.Text.Json.Serialization;

namespace GitLabRest.Model;

public class GitLabRelease
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    /// <summary>
    /// The tag where the release is created from. Required: yes
    /// </summary>
    [JsonPropertyName("tag_name")]
    public string? TagName { get; set; }
    
    /// <summary>
    /// The description of the release. You can use Markdown. Required: no
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    /// <summary>
    /// If a tag specified in tag_name doesn’t exist, the release is created from ref and tagged with tag_name. It can be a commit SHA, another tag name, or a branch name. Required: yes, if tag_name does not exits
    /// </summary>
    [JsonPropertyName("ref")]
    public string? Ref { get; set; }
    
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }
    
    [JsonPropertyName("released_at")]
    public string? ReleasedAt { get; set; }
    
    [JsonPropertyName("upcoming_release")]
    public bool? UpcomingRelease { get; set; }
    
    [JsonPropertyName("author")]
    public GitLabAuthor? Author { get; set; }
    
    [JsonPropertyName("commit")]
    public GitLabCommit? Commit { get; set; }
    
    [JsonPropertyName("commit_path")]
    public string? CommitPath { get; set; }
    
    [JsonPropertyName("tag_path")]
    public string? TagPath { get; set; }
    
    [JsonPropertyName("assets")]
    public GitLabReleaseAssets? Assets { get; set; }
    
    [JsonPropertyName("_links")]
    public GitLabReleaseLinks? Links { get; set; }
    
}

public class GitLabReleaseLinks
{
    [JsonPropertyName("closed_issues_url")]
    public string? ClosedIssuesUrl { get; set; }
    
    [JsonPropertyName("closed_merge_requests_url")]
    public string? ClosedMergeRequestsUrl { get; set; }
    
    [JsonPropertyName("edit_url")]
    public string? EditUrl { get; set; }
    
    [JsonPropertyName("merged_merge_requests_url")]
    public string? MergedMergeRequestsUrl { get; set; }
    
    [JsonPropertyName("opened_issues_url")]
    public string? OpenedIssuesUrl { get; set; }
    
    [JsonPropertyName("opened_merge_requests_url")]
    public string? OpenedMergeRequests_url { get; set; }
    
    [JsonPropertyName("self")]
    public string? Self { get; set; }
    
}