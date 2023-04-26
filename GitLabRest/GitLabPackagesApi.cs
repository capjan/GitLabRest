using System.Text.Encodings.Web;
using GitLabRest.Model;

namespace GitLabRest;

public class GitLabPackagesApi : GitLabApi
{
    public async Task<GitLabPagedResult<GitLabPackage>> ListPackagesAsync(
        int projectId,
        string packageName = "",
        long page = 1,
        int perPage = 20)
    {
        using var client = CreateHttpClient();
        
        var apiPath = $"projects/{projectId}/packages?page={page}&per_page={perPage}";
        if (!string.IsNullOrWhiteSpace(packageName)) apiPath += "&package_name=" + UrlEncoder.Default.Encode(packageName);

        var response = await client.GetAsync(apiPath);
        return await GitLabUtil.GetPaginatedResult<GitLabPackage>(response);
    }
    
    public async Task UploadGenericPackageFile(
        string filePath,
        int projectId,
        string packageName,
        string packageVersion)
    {
        using var client = CreateHttpClient();
        
        var fileData = await File.ReadAllBytesAsync(filePath);
        var fileName = Path.GetFileName(filePath).Replace(" ", "-");
        var content = new ByteArrayContent(fileData);
        
        var apiPath = $"projects/{projectId}/packages/generic/{packageName}/{packageVersion}/{fileName}";

        var response = await client.PutAsync(apiPath, content);
        var message = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"Failed to upload file. StatusCode: {response.StatusCode} Message: {message} ");
        }
    }
    
    
    public async Task<GitLabPagedResult<GitLabPackageFile>> ListPackageFilesAsync(
        int projectId,
        int packageId,
        long page = 1,
        int perPage = 20)
    {
        using var client = CreateHttpClient();
        var apiPath = $"projects/{projectId}/packages/{packageId}/package_files?page={page}&per_page={perPage}";
        var response = await client.GetAsync(apiPath);

        return await GitLabUtil.GetPaginatedResult<GitLabPackageFile>(response);
    }

    public GitLabPackagesApi(string baseUrl, string personalAccessToken) : base(baseUrl, personalAccessToken)
    {
    }
}