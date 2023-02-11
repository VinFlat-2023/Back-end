using Domain.EntitiesDTO.ContractHistoryDTO;
using Domain.EntitiesDTO.RenterDTO;

namespace Domain.EntitiesDTO.ContractDTO;

public class ContractDto
{
    public int ContractId { get; set; }

    public DateTime? DateSigned { get; set; }

    public DateTime? StartDate { get; set; }

    public string? Description { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string? ContractStatus { get; set; }

    public string? ImageUrl { get; set; }

    public double? Price { get; set; }

    public int RenterId { get; set; }

    public virtual RenterDto Renter { get; set; }

    public virtual ICollection<ContractHistoryDto> ContractHistories { get; set; }
}