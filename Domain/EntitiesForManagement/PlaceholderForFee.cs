namespace Domain.EntitiesForManagement;

public class PlaceholderForFee
{
    public int PlaceholderForFeeId { get; set; }

    // Ticket ID if any fee is created from ticket
    public int? TicketId { get; set; }

    // Contract ID if any fee is created from contract
    public int? ContractId { get; set; }

    // Name for service fee
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}