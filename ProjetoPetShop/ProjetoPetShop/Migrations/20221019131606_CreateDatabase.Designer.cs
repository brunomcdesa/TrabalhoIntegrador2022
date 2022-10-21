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
    [Migration("20221019131606_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("ProjetoPetShop.Model.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProjetoPetShop.Model.Pet", b =>
                {
                    b.Property<int>("Id_Pet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Deficiencia")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id_Cliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome_Pet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Pet");

                    b.ToTable("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
