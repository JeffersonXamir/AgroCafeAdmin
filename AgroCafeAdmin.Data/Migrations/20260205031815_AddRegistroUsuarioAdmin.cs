using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroCafeAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistroUsuarioAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SEC_Usuarios",
                columns: new[] { "Id", "Anulado", "Apellido", "Cedula", "Codigo", "Contrasenia", "Email", "FechaActualizacion", "FechaCreacion", "Nombre", "RolId" },
                values: new object[] { 1, false, "Sistemas", "0924876014001", "Admin", "123456", "AgroCafe@gmail.com", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrador", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SEC_Usuarios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
