namespace Sistran.Produto.Domain.Entity
{
    public class Product
    {
        protected Product() { }

        public Product(string nome, string descricao, double preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public Product(int id, string nome, string descricao, double preco)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public int Id { get; protected set; }

        public string Nome { get; protected set; }

        public string Descricao { get; protected set; }

        public double Preco { get; protected set; }
    }
}