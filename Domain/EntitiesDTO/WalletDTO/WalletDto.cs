using Domain.EntitiesDTO.WalletTypeDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.WalletDTO;

public class WalletDto
{
    public Guid WalletId { get; set; }
    public int Balance { get; set; }
    public DateTime CreatedDate { get; set; }
    public int RenterId { get; set; }
    public int WalletTypeId { get; set; }
    public int Status { get; set; }
    public string? WalletTypeName { get; set; }
    public string? RenterName { get; set; }

    [JsonIgnore] public virtual WalletTypeDto WalletType { get; set; } = null!;
}