﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoPetShop.Data;

namespace ProjetoPetShop.Migrations
{
    [DbContext(typeof(PetContext))]
    [Migration("20221025004427_pet")]
    partial class pet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("ProjetoPetShop.Model.Agendamento", b =>
                {
                    b.Property<int>("IdAgendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<int>("IdPet")
                        .HasColumnType("int");

                    b.HasKey("IdAgendamento");

                    b.HasIndex("IdPet");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("ProjetoPetShop.Model.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nomeCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProjetoPetShop.Model.Pet", b =>
                {
                    b.Property<int>("IdPet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Deficiencia")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("NomePet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdPet");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("ProjetoPetShop.Model.Agendamento", b =>
                {
                    b.HasOne("ProjetoPetShop.Model.Pet", "Pet")
                        .WithMany("Agendamentos")
                        .HasForeignKey("IdPet")
                        .HasConstraintName("ForeignKey_Agendamento_Pet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("ProjetoPetShop.Model.Pet", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
