using EasyOrder.Business.Interfaces.INotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOrder.Business.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification Notification)
        {
            _notifications.Add(Notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
