namespace Sistran.Produto.Application.Interface.Base
{
    public interface IBaseAppService
    {
        void BeginTransaction();

        void Commit();
    }
}