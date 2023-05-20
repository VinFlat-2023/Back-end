using System.Globalization;
using Domain.ViewModel.RenterEntity;

namespace Domain.ViewModel.ContractEntity;

public class ContractBasicDetailEntity
{
    public int ContractId { get; set; }
    public string ContractSerialNumber { get; set; }
    public string ContractName { get; set; }
    public DateTime DateSigned { get; set; }

    public string DateSignedReturn
        => DateSigned.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public DateTime StartDate { get; set; }

    public string StartDateReturn
        => StartDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public DateTime CreatedDate { get; set; }

    public string CreatedDateReturn
        => CreatedDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public DateTime? EndDate { get; set; }

    public string? EndDateReturn
        => EndDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public DateTime LastUpdated { get; set; }

    public string LastUpdatedReturn
        => LastUpdated.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public string Description { get; set; }
    public string ContractStatus { get; set; }
    public int RenterId { get; set; }
    public RenterBasicDetailEntity Renter { get; set; }
    public string?[]? ImageUrls { get; set; }
}