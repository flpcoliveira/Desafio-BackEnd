using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoRentManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class MotoRenomeiaCampoIdentificacaoParaIdentificador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identificacao",
                table: "MOTOS",
                newName: "Identificador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identificador",
                table: "MOTOS",
                newName: "Identificacao");
        }
    }
}
