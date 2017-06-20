using Sistran.Kernel.Infra.Data.Contract;
using Sistran.Produto.Application.Interface.Base;

namespace Sistran.Produto.Application.Applications.Base
{
    public class BaseAppService: IBaseAppService
    {
        private readonly IUnitOfWork _uow;

        public BaseAppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }
    }
}