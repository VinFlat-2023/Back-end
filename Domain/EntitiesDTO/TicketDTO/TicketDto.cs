using Domain.EntitiesDTO.AccountDTO;
using Domain.EntitiesDTO.InvoiceDetailDTO;
using Domain.EntitiesDTO.RenterDTO;
using Domain.EntitiesDTO.TicketTypeDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.TicketDTO;

public class TicketDto
{
    public int RequestId { get; set; }

    public string? RequestName { get; set; }

    public string? Description { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? SolveDate { get; set; }

    public double? Amount { get; set; }

    public string Status { get; set; } = null!;

    public int? RequestTypeId { get; set; }

    // Renter
    public int RenterId { get; set; }

    [JsonIgnore] public virtual RenterDto Renter { get; set; } = null!;

    // Management
    public int AccountId { get; set; }

    [JsonIgnore] public virtual AccountDto Account { get; set; } = null!;

    [JsonIgnore] public virtual ICollection<InvoiceDetailDto> InvoiceDetails { get; set; } = null!;

    [JsonIgnore] public virtual TicketTypeDto TicketType { get; set; } = null!;
}