using Application.IRepository;
using Domain.Constants;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Domain.Options;
using Domain.Utils;
using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.IService;
using Notification = Domain.EntitiesForManagement.Notification;

namespace Service.Service;

public class NotificationService : INotificationService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public NotificationService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> options)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = options.Value;
    }


    public async Task<Notification> GetNotificationById(int notiId)
    {
        var noti = await _repositoryWrapper.Notifications.GetNotificationById(notiId);
        return noti;
    }

    public async Task<PagedList<Notification>> GetNotiListByRenterIdPaging(string userName, int? page, int? pageSize)
    {
        var query = _repositoryWrapper.Notifications.GetNotiListByUserName(userName);
        if (query == null || query.Count() == 0) return null;
        var pageNumber = page ?? _paginationOptions.DefaultPageNumber;
        var size = pageSize ?? _paginationOptions.DefaultPageSize;
        var pagedList = await PagedList<Notification>.Create(query, pageNumber, size);
        return pagedList;
    }

    public async Task<bool> MarkReadStatusNotification(string userName)
    {
        var notifications = await _repositoryWrapper.Notifications.GetNotiListByUserNameToUpdate(userName);
        if (!notifications.IsNullOrEmpty())
        {
            var result = await _repositoryWrapper.Notifications.UpdateBulkNotification(notifications);
            return result;
        }

        return false;
    }

    public async Task PushAndSaveNotification(string userName, Notification notification, CancellationToken token)
    {
        var user = await _repositoryWrapper.Renters.GetARenterByUserName(userName);
        var account = new Employee();
        if (user == null) return;

        await _repositoryWrapper.Notifications.SaveNotification(notification);

        if (user == null) account = await _repositoryWrapper.Employees.GetEmployeeByUserName(userName, token);


        if (user != null)
        {
            user.UserDevices = await _repositoryWrapper.Devices.GetDeviceByUserName(user.Username);
            await SendMessageNotification(user.UserDevices, notification, user.FullName);
        }

        if (account != null)
        {
            account.UserDevices = await _repositoryWrapper.Devices.GetDeviceByUserName(account.Username);

            if (!account.UserDevices.IsNullOrEmpty())
                await SendMessageNotification(account.UserDevices, notification, account.Username);
        }
    }

    public async Task PushAndSaveNotifications(List<string> listUserName, Notification notification)
    {
        var listNotification = new List<Notification>();

        foreach (var userId in listUserName)
        {
            var user = await _repositoryWrapper.Renters.GetARenterByUserName(userId);
            if (user == null) continue;
            var tokenList = new List<string>();
            foreach (var item in user.UserDevices) tokenList.Add(item.DeviceToken);

            var messages = new MulticastMessage
            {
                Data = new Dictionary<string, string>
                {
                    { "title", notification.Title },
                    { "body", notification.Content },
                    { "receiver", user.FullName }
                },
                Tokens = tokenList
            };
            await FirebaseMessaging.DefaultInstance.SendMulticastAsync(messages);

            var userNotification = new Notification();
            notification.CloneEntity(userNotification);

            userNotification.UserName = userId;
            listNotification.Add(userNotification);
        }

        await _repositoryWrapper.Notifications.SaveNotifications(listNotification);
    }

    public async Task<bool> PushMultiNotifications(string userName, Notification noti, CancellationToken token)
    {
        try
        {
            var user = await _repositoryWrapper.Renters.GetARenterByUserName(userName);
            var account = new Employee();
            if (user == null)
            {
                account = await _repositoryWrapper.Employees.GetEmployeeByUserName(userName, token);
                if (user == null) return false;
            }


            if (user != null)
            {
                user.UserDevices = await _repositoryWrapper.Devices.GetDeviceByUserName(user.Username);
                if (!user.UserDevices.IsNullOrEmpty())
                    return await SendMessageNotification(user.UserDevices, noti, user.FullName);

                return false;
            }

            if (account != null)
            {
                account.UserDevices = await _repositoryWrapper.Devices.GetDeviceByUserName(account.Username);

                if (!account.UserDevices.IsNullOrEmpty())
                    return await SendMessageNotification(account.UserDevices, noti, account.Username);

                return false;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Task<Notification> SaveNotification(Notification notification)
    {
        var notiSave = _repositoryWrapper.Notifications.SaveNotification(notification);
        return notiSave;
    }


    public async Task<bool> UpdateStatusNotification(int notiId, string userName)
    {
        var result = await _repositoryWrapper.Notifications.UpdateStatusNotificationByUserName(notiId, userName);
        return result;
    }


    private uint GetActionColorHex(ColorEnum color)
    {
        switch (color)
        {
            case ColorEnum.Red:
                return ColorConstant.Red;
            case ColorEnum.Green:
                return ColorConstant.Green;
            case ColorEnum.Blue:
                return ColorConstant.Blue;
            case ColorEnum.Yellow:
            default:
                return ColorConstant.Yellow;
        }
    }

    private async Task<bool> SendMessageNotification(ICollection<UserDevice> deviceList, Notification noti,
        string fullName)
    {
        var tokenList = new List<string>();
        foreach (var item in deviceList) tokenList.Add(item.DeviceToken);

        if (tokenList == null || tokenList.Count == 0) return false;

        var messages = new MulticastMessage
        {
            Data = new Dictionary<string, string>
            {
                { "title", noti.Title },
                { "body", noti.Content },
                { "receiver", fullName }
            },
            Tokens = tokenList
        };
        var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(messages);
        Console.WriteLine("Successfully: " + response);
        return response != null;
    }
}