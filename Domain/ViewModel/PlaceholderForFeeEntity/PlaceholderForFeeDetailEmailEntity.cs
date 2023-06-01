namespace Domain.ViewModel.PlaceholderForFeeEntity;

public class PlaceholderForFeeDetailEmailEntity
{
    public int PlaceholderForFeeId { get; set; }
    public int? TicketId { get; set; }
    public int? ContractId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}