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
}