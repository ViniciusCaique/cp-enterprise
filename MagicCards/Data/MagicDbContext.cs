using MagicCards.Models;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Carta>().ToTable("Carta");
            modelBuilder.Entity<Colecao>().ToTable("Enrollment");
            modelBuilder.Entity<Ilustrador>().ToTable("Student");
        }
    }
}
