namespace Domain.EntitiesForManagement;

public class PlaceholderForFee
{
    public int PlaceholderForFeeId { get; set; }
    public int? TicketId { get; set; }
    public int? ContractServiceId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal? Amount { get; set; }
}