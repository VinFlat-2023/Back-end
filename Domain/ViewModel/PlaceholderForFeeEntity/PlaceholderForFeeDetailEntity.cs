namespace Domain.ViewModel.PlaceholderForFeeEntity;

public class PlaceholderForFeeDetailEntity
{
    public int PlaceholderForFeeId { get; set; }
    public int? TicketId { get; set; }
    public int? ContractId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}