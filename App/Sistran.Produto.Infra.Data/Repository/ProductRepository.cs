using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Sistran.Kernel.Infra.Data.Context;
using Sistran.Produto.Domain.Contract.Repository;
using Sistran.Produto.Domain.Entity;

namespace Sistran.Produto.Infra.Data.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly AppContext _context;

        public ProductRepository(AppContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public void RemoveProduct(int id)
        {
            // _context.Entry(product).State = EntityState.Deleted;
            _context.Database.ExecuteSqlCommand("DELETE FROM Product WHERE Id = " + id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}