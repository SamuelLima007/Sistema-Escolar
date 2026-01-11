using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNotas.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Section",
                table: "Class");

            migrationBuilder.RenameColumn(
                name: "MyTaskId",
                table: "Task",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Subject",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Subject");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Task",
                newName: "MyTaskId");

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Class",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }
    }
}
