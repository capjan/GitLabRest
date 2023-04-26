using System.Text.Encodings.Web;
using GitLabRest.Model;

namespace GitLabRest;

public class GitLabProjectsApi : GitLabApi
{
    public async Task<GitLabPagedResult<GitLabProject>> ListProjectsAsync(
        bool? membership = null,
        bool? owned = null,
        bool? starred = null,
        string? search = null,
        int page = 0,
        int perPage = 20)
    {
        using var client = CreateHttpClient();

        var uri = $"projects?page={page}&per_page={perPage}";
        if (starred.HasValue) uri += $"&starred={starred.Value}";
        if (owned.HasValue) uri += $"&owned={owned.Value}";
        if (membership.HasValue) uri += $"&membership={membership.Value}";
        if (!string.IsNullOrWhiteSpace(search)) uri += "&search=" + UrlEncoder.Default.Encode(search);

        // Make the request to the GitLab API to get all projects
        var response = await client.GetAsync(uri);
        
        return await GitLabUtil.GetPaginatedResult<GitLabProject>(response);
    }

    public GitLabProjectsApi(string baseUrl, string personalAccessToken) : base(baseUrl, personalAccessToken)
    {
    }
}