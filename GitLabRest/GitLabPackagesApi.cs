using System.Text.Encodings.Web;
using System.Text.Json;
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
    
    public async Task<GitLabPackageFile> UploadGenericPackageFileAsync(
        string filePath,
        int projectId,
        string packageName,
        string packageVersion)
    {
        // See: https://docs.gitlab.com/ee/user/packages/generic_packages/#download-package-file
        
        using var client = CreateHttpClient();
        
        var fileData = await File.ReadAllBytesAsync(filePath);
        var fileName = Path.GetFileName(filePath).Replace(" ", "-");
        var content = new ByteArrayContent(fileData);
        
        var apiPath = $"projects/{projectId}/packages/generic/{packageName}/{packageVersion}/{fileName}?select=package_file";

        var response = await client.PutAsync(apiPath, content);
        return await GitLabUtil.GetSingle<GitLabPackageFile>(response);
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