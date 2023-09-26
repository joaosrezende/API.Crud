using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration; 

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ClienteProduto> ClienteProduto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ClienteProduto>()
                .HasKey(cp => new { cp.ClienteId, cp.ProdutoId });

            modelBuilder.Entity<ClienteProduto>()
                .HasOne(cp => cp.Cliente)
                .WithMany(c => c.ClientesProdutos)
                .HasForeignKey(cp => cp.ClienteId);

            modelBuilder.Entity<ClienteProduto>()
                .HasOne(cp => cp.Produto)
                .WithMany(p => p.ClientesProdutos)
                .HasForeignKey(cp => cp.ProdutoId);

            modelBuilder.Entity<ClienteProduto>().ToTable("ClienteProduto"); // Adicione esta linha

        }
    }
}
