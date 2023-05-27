/*
using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class NotificationRepository : INotificationRepository
{
    private readonly ApplicationContext _context;

    public NotificationRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Notification> GetNotificationById(int notiId)
    {
        var notification = await _context.Notifications
            .Include(n => n.NotificationType)
            .Where(n => n.NotificationId.Equals(notiId)).AsNoTracking()
            .FirstOrDefaultAsync();
        return notification;
    }


    public async Task<Notification> SaveNotification(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();
        return notification;
    }

    public async Task SaveNotifications(List<Notification> notification)
    {
        await _context.Notifications.AddRangeAsync(notification);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateBulkNotification(List<Notification> notificationList)
    {
        try
        {
            foreach (var item in notificationList) item.IsRead = true;

            _context.Notifications.UpdateRange(notificationList);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IQueryable<Notification> GetNotiListByUserName(string userName)
    {
        var result = _context.Notifications
            .Include(n => n.NotificationType)
            .Where(n => n.UserName.Equals(userName))
            .AsNoTracking()
            .OrderByDescending(no => no.Time);
        return result;
    }


    public async Task<List<Notification>> GetNotiListByUserNameToUpdate(string userName)
    {
        var result = await _context.Notifications
            .Include(n => n.NotificationType)
            .Where(n => n.UserName.Equals(userName))
            .ToListAsync();
        return result;
    }

    public async Task<bool> UpdateStatusNotificationByUserName(int notificationId, string userName)
    {
        try
        {
            var notification = await _context.Notifications
                .Where(n => n.NotificationId.Equals(notificationId)
                            && n.UserName.Equals(userName))
                .FirstOrDefaultAsync();
            if (notification == null) return false;
            notification.IsRead = true;
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

*/

