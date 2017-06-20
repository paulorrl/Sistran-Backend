using Sistran.Kernel.Domain.DomainEvents.Container;
using Sistran.Kernel.Domain.DomainEvents.Events;
using Sistran.Kernel.Domain.DomainEvents.Handler;

namespace Sistran.Kernel.Domain.DomainEvents
{
    public static class DomainEvent
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T evento) where T : IDomainEvent
        {
            ((IHandler<T>)Container.GetService(typeof(IHandler<T>))).Handle(evento);
        }
    }
}