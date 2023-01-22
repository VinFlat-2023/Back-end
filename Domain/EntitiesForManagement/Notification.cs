namespace Domain.EntitiesForManagement;

public class Notification
{
    public int NotificationId { get; set; }
    public string Content { get; set; } = null!;
    public string Title { get; set; } = null!;
    public DateTime Time { get; set; }
    public bool IsRead { get; set; }
    public int NotificationTypeId { get; set; }
    public Guid ActionId { get; set; }
    public int ActionStatusColor { get; set; }
    public string UserName { get; set; } = null!;

    public virtual NotificationType NotificationType { get; set; } = null!;
}