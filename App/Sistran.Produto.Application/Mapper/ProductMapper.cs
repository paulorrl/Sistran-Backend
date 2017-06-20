using System.Collections.Generic;
using System.Linq;
using Sistran.Kernel.Domain.CQSeparation.Command;
using Sistran.Kernel.Domain.CQSeparation.Query;
using Sistran.Produto.Domain.Contract.Factory;
using Sistran.Produto.Domain.Entity;

namespace Sistran.Produto.Application.Mapper
{
    public class ProductMapper
    {
        private readonly IProductFactory _factory;

        public ProductMapper(IProductFactory factory)
        {
            _factory = factory;
        }

        public ProductQuery ProductToProductQuery(Product product)
        {
            return new ProductQuery { Id  = product.Id, Nome = product.Nome, Descricao = product.Descricao, Preco = product.Preco };
        }

        public IEnumerable<ProductsListQuery> ListProductsToListProductsQuery(IEnumerable<Product> products)
        {
            return products.Select(p => new ProductsListQuery { Id = p.Id, Nome = p.Nome, Descricao = p.Descricao, Preco = p.Preco }).ToList();
        }

        public Product CommandNewToProduct(NewProductCommand command)
        {
            return _factory.CreateInstance(command.Nome, command.Descricao, command.Preco);
        }

        public Product CommandUpdateToProduct(UpdateProductCommand command)
        {
            return _factory.CreateInstance(command.Id, command.Nome, command.Descricao, command.Preco);
        }
    }
}