using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface INotificationRepository
{
    public IQueryable<Notification> GetNotiListByUserName(string userName);
    public Task<List<Notification>> GetNotiListByUserNameToUpdate(string userName);
    public Task<Notification> GetNotificationById(int notiId);
    public Task<Notification> SaveNotification(Notification notification);
    public Task SaveNotifications(List<Notification> notification);
    public Task<bool> UpdateStatusNotificationByUserName(int notificationId, string userName);
    public Task<bool> UpdateBulkNotification(List<Notification> notificationList);
}