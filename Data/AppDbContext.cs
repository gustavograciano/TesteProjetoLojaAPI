using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TesteProjetoLojaAPI.Models;


namespace TesteProjetoLojaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Pedido> Pedido { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais, como chaves primárias, índices, etc.
        }
    }
}
