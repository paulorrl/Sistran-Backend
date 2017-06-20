using Sistran.Produto.Domain.Contract.Factory;
using Sistran.Produto.Domain.Entity;

namespace Sistran.Produto.Domain.Factory
{
    public class ProductFactory : IProductFactory
    {
        public Product CreateInstance(string nome, string descricao, double preco)
        {
            return new Product(nome, descricao, preco);
        }

        public Product CreateInstance(int id, string nome, string descricao, double preco)
        {
            return new Product(id, nome, descricao, preco);
        }
    }
}