using System;
using System.Collections.Generic;
using Sistran.Kernel.Domain.DomainEvents.Events;

namespace Sistran.Kernel.Domain.DomainEvents.Handler
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);

        bool HasNotifications();

        IEnumerable<T> Notify();
    }
}