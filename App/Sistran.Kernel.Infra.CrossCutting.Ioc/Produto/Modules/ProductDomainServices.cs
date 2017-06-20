using SimpleInjector;
using Sistran.Produto.Domain.Contract.Factory;
using Sistran.Produto.Domain.Contract.Service;
using Sistran.Produto.Domain.Factory;
using Sistran.Produto.Domain.Service;

namespace Sistran.Kernel.Infra.CrossCutting.Ioc.Produto.Modules
{
    internal static class ProductDomainServices
    {
        internal static void Services(Container container)
        {
            container.Register<IProductService, ProductService>(Lifestyle.Scoped);
            container.Register<IProductFactory, ProductFactory>(Lifestyle.Singleton);
        }
    }
}