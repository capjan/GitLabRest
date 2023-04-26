using GitLabRest;
using GitLabRest.Model;

namespace GitLabRestTest;

public class UnitTestReleasesApi
{

    [Fact]
    public async Task TestListReleases()
    {
        var releasesApi = CreateSut();
        var projectId = GetTestProjectId();
        var releases = await releasesApi.ListReleasesAsync(projectId);
        Assert.NotEmpty(releases.Data);
    }

    [Fact]
    public async Task TestCreateRelease()
    {
        var releaseApi = CreateSut();
        var projectId = GetTestProjectId();

        var newRelease = new GitLabRelease
        {
            Name = "Super Duper Release",
            TagName = "v2.0",
            Ref = "main",
            Description = "My super duper release"
        };
        var createdRelease = await releaseApi.CreateReleaseAsync(projectId, newRelease);
        Assert.Equal(newRelease.Name, createdRelease.Name);
        
    }
    
    private static GitLabReleaseApi CreateSut()
    {
        var baseUrl = Environment.GetEnvironmentVariable("GITLAB_BASE_URL");
        var personalAccessToken = Environment.GetEnvironmentVariable("GITLAB_PERSONAL_ACCESS_TOKEN");
        
        Assert.NotNull(baseUrl);
        Assert.NotNull(personalAccessToken);

        return new GitLabReleaseApi(baseUrl!, personalAccessToken!);
    }

    private static int GetTestProjectId()
    {
        var testProjectIdString = Environment.GetEnvironmentVariable("GITLAB_TESTPROJECT_ID");
        Assert.NotNull(testProjectIdString);
        return int.Parse(testProjectIdString);
    }
}