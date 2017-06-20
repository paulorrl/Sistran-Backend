using SimpleInjector;
using Sistran.Produto.Application.Applications;
using Sistran.Produto.Application.Applications.Base;
using Sistran.Produto.Application.Interface;
using Sistran.Produto.Application.Interface.Base;

namespace Sistran.Kernel.Infra.CrossCutting.Ioc.Produto.Modules
{
    internal static class ProductApplicationServices
    {
        internal static void Services(Container container)
        {
            container.Register<IBaseAppService, BaseAppService>(Lifestyle.Scoped);
            container.Register<IProductApplication, ProductApplication>(Lifestyle.Scoped);
        }
    }
}