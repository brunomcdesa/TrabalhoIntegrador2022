﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoPetShop.Data;

namespace ProjetoPetShop.Migrations
{
    [DbContext(typeof(PetContext))]
    [Migration("20221025002205_PetShop")]
    partial class PetShop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("ProjetoPetShop.Model.Servico", b =>
                {
                    b.Property<int>("IdServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TipoServico")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("IdServico");

                    b.ToTable("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
