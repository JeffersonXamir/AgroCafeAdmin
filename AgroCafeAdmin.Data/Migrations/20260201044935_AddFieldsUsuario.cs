using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroCafeAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "SEC_Usuarios",
                newName: "Anulado");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "SEC_Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "SEC_Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contrasenia",
                table: "SEC_Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "SEC_Usuarios");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "SEC_Usuarios");

            migrationBuilder.DropColumn(
                name: "Contrasenia",
                table: "SEC_Usuarios");

            migrationBuilder.RenameColumn(
                name: "Anulado",
                table: "SEC_Usuarios",
                newName: "Activo");
        }
    }
}
