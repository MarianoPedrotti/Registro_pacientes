using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro_pacientes.Migrations
{
    /// <inheritdoc />
    public partial class segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "ObrasSociales");

            migrationBuilder.DropColumn(
                name: "ObraSocialId",
                table: "ObrasSociales");

            migrationBuilder.DropColumn(
                name: "Sintomas",
                table: "ObrasSociales");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ObraSocialId",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sintomas",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ObraSocialId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Sintomas",
                table: "Pacientes");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "ObrasSociales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ObraSocialId",
                table: "ObrasSociales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sintomas",
                table: "ObrasSociales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
