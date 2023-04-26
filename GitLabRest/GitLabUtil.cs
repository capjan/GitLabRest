using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text.Json;
using GitLabRest.Model;

namespace GitLabRest;

public static class GitLabUtil
{
    public static HttpClient CreateHttpClient(string baseUrl, string personalAccessToken)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri($"https://{baseUrl}/api/v4/");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", personalAccessToken);
        return client;
    }

    public static GitLabPaginationInfo GetPaginationInfo(HttpResponseMessage response)
    {
        var page = int.Parse(response.Headers.GetValues("x-page").First());
        var pagesTotal = int.Parse(response.Headers.GetValues("x-total-pages").First());
        var perPage = int.Parse(response.Headers.GetValues("x-per-page").First());
        var total = int.Parse(response.Headers.GetValues("x-total").First());
        
        return new GitLabPaginationInfo(page, pagesTotal, perPage, total);
    }

    public static async Task<GitLabPagedResult<T>> GetPaginatedResult<T>(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new InvalidOperationException(
                $"Call failed with status code {response.StatusCode}: {response.ReasonPhrase}");
        
       var pagination = GetPaginationInfo(response);

        // Deserialize the response content into an array of projects
        var dataAsString = await response.Content.ReadAsStringAsync();
        var dataArray = JsonSerializer.Deserialize<T[]>(dataAsString) ?? Array.Empty<T>();
        var data = new ReadOnlyCollection<T>(dataArray);
        
        return new GitLabPagedResult<T>(
            data: data, 
            total: pagination.Total,
            page: pagination.Page,
            totalPages: pagination.TotalPages,
            perPage: pagination.PerPage);
    }
}