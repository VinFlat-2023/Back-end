using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class FlatTypeFilterRequest : PagingFilter
{
    public string? FlatTypeName { get; set; }

    public int? RoomCapacity { get; set; }

    public bool? Status { get; set; }
}