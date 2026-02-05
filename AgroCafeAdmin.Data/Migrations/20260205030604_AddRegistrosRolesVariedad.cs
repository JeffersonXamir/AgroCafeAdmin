using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroCafeAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistrosRolesVariedad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PRO_Variedades",
                columns: new[] { "Id", "Anulado", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Arábica" },
                    { 2, false, "Robusta" },
                    { 3, false, "Caturra" },
                    { 4, false, "Borbón" },
                    { 5, false, "Típica" }
                });

            migrationBuilder.InsertData(
                table: "SEC_Roles",
                columns: new[] { "Id", "Anulado", "Codigo", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "0001", "Administrador" },
                    { 2, false, "0002", "Productor" },
                    { 3, false, "0003", "Cliente" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PRO_Variedades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PRO_Variedades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PRO_Variedades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PRO_Variedades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PRO_Variedades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SEC_Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SEC_Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SEC_Roles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
