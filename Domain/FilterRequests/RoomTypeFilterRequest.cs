using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class RoomTypeFilterRequest : PagingFilter
{
    public string? Description { get; set; }
    public int? NumberOfSlots { get; set; }
}