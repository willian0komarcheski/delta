using loja1.Models;
using Microsoft.EntityFrameworkCore;

namespace loja1.Data
{
        public class lojaDbContext : DbContext
        {
            public lojaDbContext(DbContextOptions<lojaDbContext> option) : base(option)
            {
            }
            public DbSet<Produto> Produtos { get; set; }
            public DbSet<login> logins { get; set; }
            public DbSet<carrinho> carrinhos { get; set; }
            public DbSet<Agranel> Agraneis { get; set; }
            public DbSet<Aluguel> Alugueis { get; set; }
            public DbSet<Carro> Carros { get; set; }
            public DbSet<Perecivel> Pereciveis { get; set; }
            public DbSet<Remedio> Remedios { get; set; }
        }
    }
