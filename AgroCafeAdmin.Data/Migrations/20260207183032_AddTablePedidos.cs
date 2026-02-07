using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroCafeAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VEN_PEDIDOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroFactura = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEN_PEDIDOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VEN_PEDIDOS_CLI_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "CLI_Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VEN_DETALLES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    LoteId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEN_DETALLES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VEN_DETALLES_VEN_PEDIDOS_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "VEN_PEDIDOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VEN_DETALLES_PedidoId",
                table: "VEN_DETALLES",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_VEN_PEDIDOS_ClienteId",
                table: "VEN_PEDIDOS",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VEN_DETALLES");

            migrationBuilder.DropTable(
                name: "VEN_PEDIDOS");
        }
    }
}
