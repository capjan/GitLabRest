using System.Collections.ObjectModel;

namespace GitLabRest.Model;

public class GitLabPagedResult<T>
{
    public GitLabPagedResult(ReadOnlyCollection<T> data, long total, long page, long totalPages, int perPage)
    {
        Data = data;
        Total = total;
        Page = page;
        TotalPages = totalPages;
        PerPage = perPage;
    }

    public long Total { get; }
    public long Page { get; }
    public long TotalPages { get; }
    public int PerPage { get; }
    public ReadOnlyCollection<T> Data { get; }
}