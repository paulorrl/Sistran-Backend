using System.Collections.Generic;
using Sistran.Produto.Domain.Contract.Repository;
using Sistran.Produto.Domain.Contract.Service;
using Sistran.Produto.Domain.Entity;

namespace Sistran.Produto.Domain.Service
{
    public class ProductService: IProductService
    {
        /* Aqui ficariam as regras de negócios
         * Entretanto, contexto simples (Apenas CRUD)
         * Não há regras de negócios / complexas */

        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repository.GetProducts();
        }

        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddProduct(Product product)
        {
            _repository.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }

        public void RemoveProduct(int id)
        {
            _repository.RemoveProduct(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}