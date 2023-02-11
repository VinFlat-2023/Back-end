using Domain.EntitiesDTO.ContractDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.ContractHistoryDTO;

public class ContractHistoryDto
{
    public int ContractHistoryId { get; set; }

    public double? Price { get; set; }

    public string Description { get; set; } = null!;

    public string? ContractHistoryStatus { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? ContractExpiredDate { get; set; }

    public int ContractId { get; set; } // Contract

    [JsonIgnore] public virtual ContractDto Contract { get; set; } = null!;
}