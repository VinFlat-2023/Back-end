using System.Globalization;
using Domain.ViewModel.FlatEntity;
using Domain.ViewModel.RenterEntity;

namespace Domain.ViewModel.ContractEntity;

public class ContactDetailRenterEntity
{
    public int ContractId { get; set; }
    public string ContractSerialNumber { get; set; }
    public string ContractName { get; set; }
    public DateTime DateSigned { get; set; }

    public string DateSignedReturn
        => LastUpdated.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public DateTime StartDate { get; set; }

    public string StartDateReturn
        => LastUpdated.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public DateTime CreatedDate { get; set; }

    public string CreatedDateReturn
        => LastUpdated.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public string Description { get; set; }
    public DateTime? EndDate { get; set; }

    public string EndDateReturn
        => LastUpdated.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public DateTime LastUpdated { get; set; }

    public string LastUpdatedReturn
        => LastUpdated.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public string ContractStatus { get; set; }
    public string PriceForRent { get; set; }
    public string PriceForWater { get; set; }
    public string PriceForElectricity { get; set; }
    public string PriceForService { get; set; }
    public string?[]? ImageUrls { get; set; }
    public int RenterId { get; set; }
    public RenterDetailEntity Renter { get; set; }
    public int FlatId { get; set; }
    public FlatDetailEntity Flat { get; set; }
    public int RoomId { get; set; }
}