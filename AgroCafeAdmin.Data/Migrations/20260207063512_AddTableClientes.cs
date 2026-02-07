using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroCafeAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLI_Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Anulado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLI_Clientes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CLI_Clientes",
                columns: new[] { "Id", "Anulado", "Email", "RazonSocial", "Ruc", "Telefono", "Tipo" },
                values: new object[] { 1, false, "AgroCafe@gmail.com", "Consumidor Final", "9999999999", "999999999", "Nacional" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLI_Clientes");
        }
    }
}
