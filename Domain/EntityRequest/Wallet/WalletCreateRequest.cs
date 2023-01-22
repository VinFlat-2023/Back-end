using Domain.EnumEntities;

namespace Domain.EntityRequest.Wallet;

public class WalletCreateRequest
{
    public WalletTypeEnum WalletType { get; set; }
}