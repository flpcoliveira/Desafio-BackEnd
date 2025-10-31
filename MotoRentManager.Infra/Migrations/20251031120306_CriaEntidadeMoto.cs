using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoRentManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriaEntidadeMoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MOTOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Identificacao = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Ano = table.Column<int>(type: "integer", nullable: false),
                    Modelo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Placa = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTOS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MOTOS");
        }
    }
}
