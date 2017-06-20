using Sistran.Produto.Domain.Entity;

namespace Sistran.Produto.Domain.Contract.Factory
{
    public interface IProductFactory
    {
        Product CreateInstance(string nome, string descricao, double preco);

        Product CreateInstance(int id, string nome, string descricao, double preco);
    }
}