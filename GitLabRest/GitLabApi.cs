namespace GitLabRest;

public abstract class GitLabApi
{
    private string BaseUrl { get; }
    private string PersonalAccessToken { get; }

    protected GitLabApi(string baseUrl, string personalAccessToken)
    {
        BaseUrl = baseUrl;
        PersonalAccessToken = personalAccessToken;
    }

    protected HttpClient CreateHttpClient()
    {
        return GitLabUtil.CreateHttpClient(BaseUrl, PersonalAccessToken);
    }

    public static IGitLabApi Create(string baseUrl, string personalAccessToken)
    {
        return new GitLabApiImplementation(baseUrl, personalAccessToken);
    }
}

public interface IGitLabApi
{
    GitLabPackagesApi Packages { get; }
    GitLabProjectsApi Projects { get; }
    GitLabReleaseApi Releases { get; }
}

internal class GitLabApiImplementation : IGitLabApi
{
    public GitLabPackagesApi Packages { get; }
    public GitLabProjectsApi Projects { get; }
    public GitLabReleaseApi Releases { get; }

    public GitLabApiImplementation(string baseUrl, string personalAccessToken)
    {
        Packages = new GitLabPackagesApi(baseUrl, personalAccessToken);
        Projects = new GitLabProjectsApi(baseUrl, personalAccessToken);
        Releases = new GitLabReleaseApi(baseUrl, personalAccessToken);
    }
}