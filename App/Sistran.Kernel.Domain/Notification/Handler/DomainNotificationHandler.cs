using System.Collections.Generic;
using Sistran.Kernel.Domain.DomainEvents.Handler;
using Sistran.Kernel.Domain.Notification.Event;

namespace Sistran.Kernel.Domain.Notification.Handler
{
    public class DomainNotificationHandler : IHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications = new List<DomainNotification>();

        private List<DomainNotification> GetValue()
        {
            return this._notifications;
        }

        public void Handle(DomainNotification args)
        {
            this._notifications.Add(args);
        }

        public bool HasNotifications()
        {
            return (this.GetValue().Count > 0);
        }

        public IEnumerable<DomainNotification> Notify()
        {
            return this.GetValue();
        }

        public void Dispose()
        {
            this._notifications = new List<DomainNotification>();
        }
    }
}