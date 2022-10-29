using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjetoPetShop.Model;

namespace ProjetoPetShop.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>()
                // aqui ta fazendo a relação só de um lado , onde tem 1 pet para 1 agendamento
                .HasOne(p => p.Pet)
                .WithOne(pet => pet.Agendamentos)
                .HasForeignKey<Agendamento>(p => p.IdPet);
                // não precisa disso: .HasConstraintName("ForeignKey_Agendamento_Pet");
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
