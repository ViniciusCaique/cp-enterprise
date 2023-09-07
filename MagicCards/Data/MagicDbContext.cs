using MagicCards.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace MagicCards.Data
{
    public class MagicDbContext : DbContext
    {
        public MagicDbContext(DbContextOptions<MagicDbContext> options) : base(options) { }

        public DbSet<Carta> Cartas { get; set; }
        public DbSet<Colecao> Colecoes { get; set; }
        public DbSet<Ilustrador> Ilustradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Carta>().HasOne(r => r.Colecao).WithMany(q => q.Cartas).OnDelete(deleteBehavior: DeleteBehavior.Cascade);
            modelBuilder.Entity<Carta>().ToTable("Carta");
            modelBuilder.Entity<Colecao>().ToTable("Colecoes");
            modelBuilder.Entity<Ilustrador>().ToTable("Ilustradores");
        }
    }   
}
