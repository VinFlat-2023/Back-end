using Domain.EnumEntities;

namespace Domain.EntitiesDTO.NotificationDTO;

public class NotificationDTO
{
    public int NotificationId { get; set; }
    public int? AccountId { get; set; }
    public int? RenterId { get; set; }
    public string Content { get; set; } = null!;
    public string Title { get; set; } = null!;
    public DateTime Time { get; set; }
    public bool IsRead { get; set; }
    public int NotificationTypeId { get; set; }
    public Guid ActionId { get; set; }
    public int ActionStatusColor { get; set; }

    // Custom Fields

    public string RenterName { get; set; }
    public string FullContent { get; set; }
    public string NotificationTypeName { get; set; }

    public string ActionStatusColorString => Enum.GetName(typeof(ColorEnum), ActionStatusColor);

    public uint ColorHex { get; set; }
}