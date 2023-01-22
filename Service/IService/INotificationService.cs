using Domain.CustomEntities;
using Domain.EntitiesForManagement;

namespace Service.IService;

public interface INotificationService
{
    public Task<bool> PushMultiNotifications(string userName, Notification noti);
    public Task PushAndSaveNotifications(List<string> userName, Notification notification);
    public Task PushAndSaveNotification(string userName, Notification notification);
    public Task<PagedList<Notification>> GetNotiListByRenterIdPaging(string userName, int? page, int? pageSize);
    public Task<bool> UpdateStatusNotification(int notiId, string userName);
    public Task<bool> MarkReadStatusNotification(string userName);
    public Task<Notification> GetNotificationById(int notiId);
    public Task<Notification> SaveNotification(Notification notification);
}