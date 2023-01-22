namespace Domain.EntitiesForManagement;

public class Wallet
{
    public Guid WalletId { get; set; }
    public int Balance { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Status { get; set; }
    public int WalletTypeId { get; set; }
    public int RenterId { get; set; }

    public virtual Renter Renter { get; set; }
    public virtual WalletType WalletType { get; set; } = null!;
}