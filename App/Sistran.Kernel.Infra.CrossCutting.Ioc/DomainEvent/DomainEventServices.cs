using SimpleInjector;
using Sistran.Kernel.Domain.DomainEvents.Handler;
using Sistran.Kernel.Domain.Notification.Event;
using Sistran.Kernel.Domain.Notification.Handler;

namespace Sistran.Kernel.Infra.CrossCutting.Ioc.DomainEvent
{
    internal static class DomainEventServices
    {
        internal static void Dependencies(Container container)
        {
            container.Register<IHandler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);
        }
    }
}