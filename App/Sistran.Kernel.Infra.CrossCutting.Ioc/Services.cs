using SimpleInjector;
using Sistran.Kernel.Infra.CrossCutting.Ioc.Data;
using Sistran.Kernel.Infra.CrossCutting.Ioc.DomainEvent;
using Sistran.Kernel.Infra.CrossCutting.Ioc.Mapper;
using Sistran.Kernel.Infra.CrossCutting.Ioc.Produto;

namespace Sistran.Kernel.Infra.CrossCutting.Ioc
{
    public static class Services
    {
        public static void Resolver(Container container)
        {
            DomainEventServices.Dependencies(container);
            ProductModule.Dependencies(container);
            MapperService.Dependencies(container);
            DataServices.Dependencies(container);
        }
    }
}