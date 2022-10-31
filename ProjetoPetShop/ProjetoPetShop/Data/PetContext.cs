using Microsoft.EntityFrameworkCore;
using ProjetoPetShop.Model;

namespace ProjetoPetShop.Data
{
    public class PetContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public PetContext(DbContextOptions<PetContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pet>()
            .HasOne(c => c.Cliente)
            .WithMany(cliente => cliente.Pets);
            //.HasForeignKey<Pet>(c => c.IdCliente);
        
        }
    }
}
