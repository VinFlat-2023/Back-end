namespace Domain.QueryFilter;

public class FlatTypeFilter : PagingFilter
{
    public int? RoomCapacity { get; set; }

    public string? Status { get; set; }
}