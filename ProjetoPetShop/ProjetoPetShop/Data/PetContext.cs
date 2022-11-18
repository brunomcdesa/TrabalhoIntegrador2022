using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjetoPetShop.Model;
using System.Collections.Generic;

namespace ProjetoPetShop.Data
{
    public class PetContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }


        public PetContext(DbContextOptions<PetContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>()
                .HasOne(c => c.Servico)
                .WithMany(servico => servico.Agendamentos)
                .HasForeignKey(fk => fk.IdServico);

            modelBuilder.Entity<Agendamento>()
                .HasOne(p => p.Pet)
                .WithMany(pet => pet.Agendamentos)
                .HasForeignKey(fk => fk.IdPet);


            modelBuilder.Entity<Agendamento>()
                .HasOne(s => s.Servico)
                .WithMany(servico => servico.Agendamentos)
                .HasForeignKey(fk => fk.IdServico);



            modelBuilder.Entity<Pet>()
                .HasOne(c => c.Cliente)
                .WithMany(cliente => cliente.Pets)
                .HasForeignKey(fk => fk.IdCliente);
        }
   
    }
}
