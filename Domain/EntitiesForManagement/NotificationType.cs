namespace Domain.EntitiesForManagement;

public class NotificationType
{
    public int NotificationTypeId { get; set; }
    public string NotificationTypeName { get; set; } = null!;
    public int Status { get; set; }
}