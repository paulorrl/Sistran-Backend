using System.Collections.Generic;
using Sistran.Kernel.Domain.CQSeparation.Command;
using Sistran.Kernel.Domain.CQSeparation.Query;

namespace Sistran.Produto.Application.Interface
{
    public interface IProductApplication
    {

        ProductQuery GetById(int id);

        IEnumerable<ProductsListQuery> GetProducts();

        void AddProduct(NewProductCommand command);

        void UpdateProduct(UpdateProductCommand command);

        void RemoveProduct(int id);
    }
}