using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Sistran.Produto.Domain.Entity;

namespace Sistran.Kernel.Infra.Data.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nome");

            Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("Descricao");

            Property(x => x.Preco)
                .IsRequired()
                .HasColumnName("Preco");
        }
    }
}