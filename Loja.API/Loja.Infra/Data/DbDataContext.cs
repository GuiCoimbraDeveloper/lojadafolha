using Loja.Domain.Entites;
using Loja.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Loja.Infra.Data
{
    public class DbDataContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItens> PedidoItens { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //var builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile("appsettings.json");
            //IConfiguration Configuration = builder.Build();

            //optionsBuilder.UseSqlServer(
            //    Configuration.GetConnectionString("DefaultConnection"));
            //base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new PedidoMapping());
        }
    }
}
