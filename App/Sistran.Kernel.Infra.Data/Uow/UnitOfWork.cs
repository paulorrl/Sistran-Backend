using Sistran.Kernel.Infra.Data.Context;
using Sistran.Kernel.Infra.Data.Contract;

namespace Sistran.Kernel.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _context;
        private bool _disposed;

        public UnitOfWork(AppContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
    }
}