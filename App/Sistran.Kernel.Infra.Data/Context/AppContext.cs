using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Sistran.Kernel.Infra.Data.Mappings;
using Sistran.Produto.Domain.Entity;

namespace Sistran.Kernel.Infra.Data.Context
{
    public class AppContext : DbContext
    {
        public AppContext() : base("AppContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #region DbSet's
        public DbSet<Product> Products { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}