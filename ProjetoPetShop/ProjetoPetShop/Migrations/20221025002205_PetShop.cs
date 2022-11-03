using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPetShop.Migrations
{
    public partial class PetShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valor",
                table: "Servicos",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "tipoServico",
                table: "Servicos",
                newName: "TipoServico");

            migrationBuilder.RenameColumn(
                name: "idServico",
                table: "Servicos",
                newName: "IdServico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Servicos",
                newName: "valor");

            migrationBuilder.RenameColumn(
                name: "TipoServico",
                table: "Servicos",
                newName: "tipoServico");

            migrationBuilder.RenameColumn(
                name: "IdServico",
                table: "Servicos",
                newName: "idServico");
        }
    }
}
