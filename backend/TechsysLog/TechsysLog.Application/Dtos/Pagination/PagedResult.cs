namespace TechsysLog.Application.Dtos.Pagination;

public class PagedResult<T>(long totalCount, List<T> items)
{
    public long TotalCount { get; set; } = totalCount;
    public List<T> Items { get; set; } = items;
}