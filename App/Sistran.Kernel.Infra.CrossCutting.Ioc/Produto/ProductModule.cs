using SimpleInjector;
using Sistran.Kernel.Infra.CrossCutting.Ioc.Produto.Modules;
using Sistran.Kernel.Infra.Data.Context;

namespace Sistran.Kernel.Infra.CrossCutting.Ioc.Produto
{
    internal static class ProductModule
    {
        internal static void Dependencies(Container container)
        {
            container.Register<AppContext>(Lifestyle.Scoped);

            ProductApplicationServices.Services(container);
            ProductDomainServices.Services(container);
            ProductInfraServices.Services(container);
        }
    }
}