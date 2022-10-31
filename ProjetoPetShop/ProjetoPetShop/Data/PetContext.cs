using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjetoPetShop.Model;
using System.Collections.Generic;

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
                .HasOne(p => p.Pet)
                .WithMany(pet => pet.Agendamentos);
            modelBuilder.Entity<Pet>()
                .HasOne(c => c.Cliente)
                .WithMany(cliente => cliente.Pets);
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
