using GitLabRest;

namespace GitLabRestTest;

public class UnitTestPackagesApi
{

    [Fact]
    public async Task ListPackagesTest()
    {
        var packagesApi = CreateSut();
        var projectId = GetTestProjectId();
        var packages = await packagesApi.ListPackagesAsync(projectId);

        Assert.NotEmpty(packages.Data);
    }
    
    [Fact]
    public async Task ListPackageFilesTest()
    {
        var packagesApi = CreateSut();
        var projectId = GetTestProjectId();
        
        var packages = await packagesApi.ListPackagesAsync(projectId);

        foreach (var package in packages.Data)
        {
            var id = package.Id ?? -1;
            var files = await packagesApi.ListPackageFilesAsync(projectId, id);
            Assert.NotEmpty(files.Data);
        }
        Assert.NotEmpty(packages.Data);
    }

    [Fact]
    public async Task UploadFileTest()
    {
        var api = CreateSut();
        var projectId = GetTestProjectId();

        var tempFile = Path.GetTempFileName();
        await File.WriteAllTextAsync(tempFile, "Hello World!");


        var uploadedFile = await api.UploadGenericPackageFileAsync(tempFile, projectId, "Test", "1.0.0");
        Assert.Equal(uploadedFile.FileName, Path.GetFileName(tempFile));
    }

    private static GitLabPackagesApi CreateSut()
    {
        var baseUrl = Environment.GetEnvironmentVariable("GITLAB_BASE_URL");
        var personalAccessToken = Environment.GetEnvironmentVariable("GITLAB_PERSONAL_ACCESS_TOKEN");
        
        Assert.NotNull(baseUrl);
        Assert.NotNull(personalAccessToken);

        return new GitLabPackagesApi(baseUrl!, personalAccessToken!);
    }
    
    
    
    private static int GetTestProjectId()
    {
        var testProjectIdString = Environment.GetEnvironmentVariable("GITLAB_TESTPROJECT_ID");
        Assert.NotNull(testProjectIdString);
        return int.Parse(testProjectIdString);
    }
}