using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroCafeAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableParcelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRO_Variedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Anulado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Variedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Area = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FincaId = table.Column<int>(type: "int", nullable: false),
                    VariedadId = table.Column<int>(type: "int", nullable: false),
                    Anulado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRO_Parcelas_PRO_Fincas_FincaId",
                        column: x => x.FincaId,
                        principalTable: "PRO_Fincas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Parcelas_PRO_Variedades_VariedadId",
                        column: x => x.VariedadId,
                        principalTable: "PRO_Variedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Parcelas_FincaId",
                table: "PRO_Parcelas",
                column: "FincaId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Parcelas_VariedadId",
                table: "PRO_Parcelas",
                column: "VariedadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRO_Parcelas");

            migrationBuilder.DropTable(
                name: "PRO_Variedades");
        }
    }
}
