namespace GitLabRest.Model;

public record struct GitLabPaginationInfo(int Page, int TotalPages, int PerPage, int Total);

