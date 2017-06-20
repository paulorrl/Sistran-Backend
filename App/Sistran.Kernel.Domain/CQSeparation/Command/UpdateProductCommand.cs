namespace Sistran.Kernel.Domain.CQSeparation.Command
{
    public class UpdateProductCommand
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public double Preco { get; set; }
    }
}