using SimpleInjector;
using Sistran.Produto.Domain.Contract.Repository;
using Sistran.Produto.Infra.Data.Repository;

namespace Sistran.Kernel.Infra.CrossCutting.Ioc.Produto.Modules
{
    internal static class ProductInfraServices
    {
        internal static void Services(Container container)
        {
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Scoped);
        }
    }
}