namespace Domain.EntityRequest.Request;

public class TicketCreateRequest
{
    public string RequestName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime? SolveDate { get; set; }
    public decimal? Amount { get; set; }
    public string Status { get; set; } = null!;
    public int TicketTypeId { get; set; }
    public int RenterId { get; set; }
    public int EmployeeId { get; set; }
}