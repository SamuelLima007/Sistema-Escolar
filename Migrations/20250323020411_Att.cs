using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNotas.Migrations
{
    /// <inheritdoc />
    public partial class Att : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "Teacher",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "Student",
                type: "Text",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "Administratores",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Administratores");
        }
    }
}
