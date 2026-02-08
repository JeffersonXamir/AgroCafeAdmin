using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroCafeAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesForInventarioModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INV_Calidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Anulado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Calidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INV_Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Anulado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Unidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INV_Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ParcelaId = table.Column<int>(type: "int", nullable: false),
                    FechaCosecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadInicial = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    StockActual = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    UnidadId = table.Column<int>(type: "int", nullable: false),
                    CalidadId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Anulado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Lotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_INV_Lotes_INV_Calidades_CalidadId",
                        column: x => x.CalidadId,
                        principalTable: "INV_Calidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Lotes_INV_Unidades_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "INV_Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INV_Movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    EsEntrada = table.Column<bool>(type: "bit", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_INV_Movimientos_INV_Lotes_LoteId",
                        column: x => x.LoteId,
                        principalTable: "INV_Lotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "INV_Calidades",
                columns: new[] { "Id", "Anulado", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Primera" },
                    { 2, false, "Segunda" },
                    { 3, false, "Descarte" }
                });

            migrationBuilder.InsertData(
                table: "INV_Unidades",
                columns: new[] { "Id", "Anulado", "Codigo", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "qq", "Quintales" },
                    { 2, false, "kg", "Kilos" },
                    { 3, false, "lb", "Libras" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_INV_Lotes_CalidadId",
                table: "INV_Lotes",
                column: "CalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Lotes_UnidadId",
                table: "INV_Lotes",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Movimientos_LoteId",
                table: "INV_Movimientos",
                column: "LoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INV_Movimientos");

            migrationBuilder.DropTable(
                name: "INV_Lotes");

            migrationBuilder.DropTable(
                name: "INV_Calidades");

            migrationBuilder.DropTable(
                name: "INV_Unidades");
        }
    }
}
