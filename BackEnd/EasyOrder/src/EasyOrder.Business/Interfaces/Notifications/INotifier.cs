using EasyOrder.Business.Notifications;
using System.Collections.Generic;

namespace EasyOrder.Business.Interfaces.INotifications
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
