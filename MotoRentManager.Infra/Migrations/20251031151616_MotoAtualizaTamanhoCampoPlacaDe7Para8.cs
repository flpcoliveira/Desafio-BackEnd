using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoRentManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class MotoAtualizaTamanhoCampoPlacaDe7Para8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "MOTOS",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(7)",
                oldMaxLength: 7);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "MOTOS",
                type: "character varying(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(8)",
                oldMaxLength: 8);
        }
    }
}
