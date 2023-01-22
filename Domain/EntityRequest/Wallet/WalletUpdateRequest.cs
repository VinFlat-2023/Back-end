namespace Domain.EntityRequest.Wallet;

public class WalletUpdateRequest
{
    public Guid WalletId { get; set; }
    public int Balance { get; set; }
}