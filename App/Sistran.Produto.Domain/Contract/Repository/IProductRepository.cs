using System;
using System.Collections.Generic;
using Sistran.Produto.Domain.Entity;

namespace Sistran.Produto.Domain.Contract.Repository
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetProducts();

        Product GetById(int id);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void RemoveProduct(int id);
    }
}