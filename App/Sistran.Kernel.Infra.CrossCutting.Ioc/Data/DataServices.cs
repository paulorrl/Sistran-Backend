using SimpleInjector;
using Sistran.Kernel.Infra.Data.Contract;
using Sistran.Kernel.Infra.Data.Uow;

namespace Sistran.Kernel.Infra.CrossCutting.Ioc.Data
{
    internal static class DataServices
    {
        internal static void Dependencies(Container container)
        {
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}