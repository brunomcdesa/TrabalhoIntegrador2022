using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ProjetoPetShop.Migrations
{
    public partial class PetShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TipoServico = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.IdServico);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    IdPet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NomePet = table.Column<string>(type: "text", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Deficiencia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Especie = table.Column<string>(type: "text", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.IdPet);
                    table.ForeignKey(
                        name: "FK_Pets_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    IdAgendamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdPet = table.Column<int>(type: "int", nullable: false),
                    IdServico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.IdAgendamento);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Pets_IdPet",
                        column: x => x.IdPet,
                        principalTable: "Pets",
                        principalColumn: "IdPet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Servicos_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servicos",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_IdPet",
                table: "Agendamentos",
                column: "IdPet");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_IdServico",
                table: "Agendamentos",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_IdCliente",
                table: "Pets",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
