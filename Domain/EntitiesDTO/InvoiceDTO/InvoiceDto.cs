using Domain.EntitiesDTO.AccountDTO;
using Domain.EntitiesDTO.InvoiceDetailDTO;
using Domain.EntitiesDTO.InvoiceTypeDTO;
using Domain.EntitiesDTO.RenterDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.InvoiceDTO;

public class InvoiceDto
{
    public int InvoiceId { get; set; }

    public string Name { get; set; } = null!;

    public int Amount { get; set; }

    public bool Status { get; set; }

    public DateTime? DueDate { get; set; }

    public string? Detail { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? PaymentTime { get; set; }

    public TimeSpan? PaymentPeriod { get; set; }

    public DateTime CreatedTime { get; set; }

    // Receiver account
    public int RenterId { get; set; }

    [JsonIgnore] public virtual RenterDto Renter { get; set; } = null!;

    // Management account
    public int? AccountId { get; set; }

    [JsonIgnore] public virtual AccountDto? Account { get; set; }

    public int InvoiceTypeId { get; set; }

    [JsonIgnore] public virtual InvoiceTypeDto InvoiceType { get; set; } = null!;

    [JsonIgnore] public virtual ICollection<InvoiceDetailDto> InvoiceDetails { get; set; } = null!;
}