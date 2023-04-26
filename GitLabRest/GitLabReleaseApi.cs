using System.Net;
using System.Text;
using System.Text.Json;
using GitLabRest.Model;

namespace GitLabRest;

public class GitLabReleaseApi : GitLabApi
{
    public async Task<GitLabPagedResult<GitLabRelease>> ListReleasesAsync(
        int projectId,
        int page = 0,
        int perPage = 20)
    {
        var uri = $"projects/{projectId}/releases?page={page}&per_page={perPage}";

        using var client = CreateHttpClient();
        var response = await client.GetAsync(uri);

        return await GitLabUtil.GetPaginatedResult<GitLabRelease>(response);
    }
    
    public async Task<GitLabRelease> CreateReleaseAsync(
        int projectId,
        GitLabRelease release)
    {
        
        var uri = $"projects/{projectId}/releases";
        var bodyContent = JsonSerializer.Serialize(release);

        var client = CreateHttpClient();
        var response = await client.PostAsync(uri,
            new StringContent(bodyContent, encoding: Encoding.UTF8, "application/json"));
        var responseBody = await response.Content.ReadAsStringAsync();
        if (response.StatusCode != HttpStatusCode.Created)
            throw new InvalidOperationException($"failed to create a release. StatusCode: {response.StatusCode}, Message: {responseBody}");
        var createdRelease = JsonSerializer.Deserialize<GitLabRelease>(responseBody);
        return createdRelease ?? throw new InvalidOperationException("failed to deserialize releases");
    }

    public GitLabReleaseApi(string baseUrl, string personalAccessToken) : base(baseUrl, personalAccessToken)
    {
    }
}