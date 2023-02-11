using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.ContractHistory;

public class ContractHistoryCreateRequest
{
    public double Price { get; set; }

    [MaxLength(200, ErrorMessage = "Description length must less than 200")]
    public string Description { get; set; } = null!;

    [MaxLength(20, ErrorMessage = "Status length must less than 20")]
    public string ContractHistoryStatus { get; set; } = null!;

    public DateTime ContractExpiredDate { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Contract Id must not be negative")]
    public int ContractId { get; set; } // Contract
}