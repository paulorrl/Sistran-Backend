using System.Collections.Generic;
using Sistran.Kernel.Domain.CQSeparation.Command;
using Sistran.Kernel.Domain.CQSeparation.Query;
using Sistran.Kernel.Domain.DomainEvents.Handler;
using Sistran.Kernel.Domain.Notification.Event;
using Sistran.Kernel.Infra.Data.Contract;
using Sistran.Produto.Application.Applications.Base;
using Sistran.Produto.Application.Interface;
using Sistran.Produto.Application.Mapper;
using Sistran.Produto.Application.Scopes.Product;
using Sistran.Produto.Domain.Contract.Service;

namespace Sistran.Produto.Application.Applications
{
    public class ProductApplication: BaseAppService, IProductApplication
    {
        /* Esta classe orquestra o fluxo e validações de estados!
        Validações de negócio ficaria no Domain (Entidades ou Services), em seu respectivo contexto
        Entretanto, a solução possuí apenas um "contexto" de produtos (Apenas CRUD)...
        ... e não possuí regras de negócios, por natureza, sendo simples demais! */

        private readonly IProductService _service;
        private readonly IHandler<DomainNotification> _notifications;
        private readonly ProductMapper _mapper;

        public ProductApplication(IProductService service, IHandler<DomainNotification> notifications, ProductMapper mapper, IUnitOfWork uow)
            : base(uow)
        {
            _service = service;
            _notifications = notifications;
            _mapper = mapper;
        }

        public ProductQuery GetById(int id)
        {
            ProductScopes.ValidationProductId(id);

            return _notifications.HasNotifications()
                   ? null
                   : _mapper.ProductToProductQuery(_service.GetById(id));
        }

        public IEnumerable<ProductsListQuery> GetProducts()
        {
            var products = _service.GetProducts();
            return _mapper.ListProductsToListProductsQuery(products);
        }

        public void AddProduct(NewProductCommand command)
        {
            ProductScopes.ValidationNewProduct(command);

            if (!_notifications.HasNotifications())
            {
                var product = _mapper.CommandNewToProduct(command);
                BeginTransaction();
                _service.AddProduct(product);
                Commit();
            }
        }

        public void UpdateProduct(UpdateProductCommand command)
        {
            ProductScopes.ValidationUpdateProduct(command);

            if (_notifications.HasNotifications()) return;

            var product = _mapper.CommandUpdateToProduct(command);
            BeginTransaction();
            _service.UpdateProduct(product);
            Commit();
        }

        public void RemoveProduct(int id)
        {
            ProductScopes.ValidationRemoveProduct(id);

            if (_notifications.HasNotifications()) return;

            BeginTransaction();
            _service.RemoveProduct(id);
            Commit();
        }
    }
}