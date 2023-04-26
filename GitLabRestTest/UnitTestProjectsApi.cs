using GitLabRest;

namespace GitLabRestTest;

public class UnitTestProjectsApi
{
    [Fact]
    public async Task Test1()
    {
        var personalAccessToken = Environment.GetEnvironmentVariable("GITLAB_PERSONAL_ACCESS_TOKEN");
        var baseUrl = Environment.GetEnvironmentVariable("GITLAB_BASE_URL");
        
        Assert.NotNull(baseUrl);
        Assert.NotNull(personalAccessToken);
        
        var projectsApi = new GitLabProjectsApi(baseUrl, personalAccessToken);
        var projects = await projectsApi.ListProjectsAsync(owned: true);
        Assert.NotEmpty(projects.Data);
    }
    
}