using System;

namespace Sistran.Kernel.Infra.Data.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void SaveChanges();
    }
}