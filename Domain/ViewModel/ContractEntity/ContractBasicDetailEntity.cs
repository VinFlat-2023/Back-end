using Domain.ViewModel.RenterEntity;

namespace Domain.ViewModel.ContractEntity;

public class ContractBasicDetailEntity
{
    public int ContractId { get; set; }
    public string ContractName { get; set; }
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public string Description { get; set; }
    public DateTime? EndDate { get; set; }
    public string ContractStatus { get; set; }
    public int RenterId { get; set; }
    public RenterBasicDetailEntity Renter { get; set; }
}