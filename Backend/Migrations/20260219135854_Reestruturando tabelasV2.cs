using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNotas.Migrations
{
    /// <inheritdoc />
    public partial class ReestruturandotabelasV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "score",
                table: "Task",
                type: "numeric(5,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Score",
                table: "SubmittedTask",
                type: "numeric(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "score",
                table: "Task",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Score",
                table: "SubmittedTask",
                type: "numeric",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)");
        }
    }
}
