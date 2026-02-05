using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroCafeAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesBitacoras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BIT_Bitacoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParcelaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NombreEvento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Severidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIT_Bitacoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BIT_Bitacoras_PRO_Parcelas_ParcelaId",
                        column: x => x.ParcelaId,
                        principalTable: "PRO_Parcelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BIT_Labores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Anulado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIT_Labores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BIT_Plagas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Anulado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIT_Plagas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BIT_Labores",
                columns: new[] { "Id", "Anulado", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Siembra" },
                    { 2, false, "Fertilización" },
                    { 3, false, "Poda" },
                    { 4, false, "Deshierbe" },
                    { 5, false, "Cosecha" }
                });

            migrationBuilder.InsertData(
                table: "BIT_Plagas",
                columns: new[] { "Id", "Anulado", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Roya" },
                    { 2, false, "Broca" },
                    { 3, false, "Ojo de Gallo" },
                    { 4, false, "Minador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BIT_Bitacoras_ParcelaId",
                table: "BIT_Bitacoras",
                column: "ParcelaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BIT_Bitacoras");

            migrationBuilder.DropTable(
                name: "BIT_Labores");

            migrationBuilder.DropTable(
                name: "BIT_Plagas");
        }
    }
}
