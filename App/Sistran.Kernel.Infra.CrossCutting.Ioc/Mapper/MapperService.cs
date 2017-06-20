using SimpleInjector;
using Sistran.Produto.Application.Mapper;

namespace Sistran.Kernel.Infra.CrossCutting.Ioc.Mapper
{
    internal static class MapperService
    {
        internal static void Dependencies(Container container)
        {
            container.RegisterSingleton<ProductMapper>();
        }
    }
}