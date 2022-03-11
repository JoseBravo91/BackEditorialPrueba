using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEditorialPrueba.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreAutor",
                table: "Libro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreEditorial",
                table: "Libro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreEditorial",
                table: "Autor",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreAutor",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "NombreEditorial",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "NombreEditorial",
                table: "Autor");
        }
    }
}
