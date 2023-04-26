using System.Text.Json.Serialization;

namespace GitLabRest.Model;

public class GitLabPackageFile
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    
    [JsonPropertyName("package_id")]
    public int? PackageId { get; set; }
    
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }
    
    [JsonPropertyName("file_name")]
    public string? FileName { get; set; }
    
    [JsonPropertyName("size")]
    public long? FileSizeInBytes { get; set; }
    
}