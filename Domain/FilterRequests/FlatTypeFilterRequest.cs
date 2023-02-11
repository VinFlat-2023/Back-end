using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class FlatTypeFilterRequest : PagingFilter
{
    public int? RoomCapacity { get; set; }

    public string? Status { get; set; }
}