using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNotas.Migrations
{
    /// <inheritdoc />
    public partial class v1000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Aluno_Id",
                table: "Nota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    AdministradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.AdministradorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nota_Aluno_Id",
                table: "Nota",
                column: "Aluno_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Aluno_Aluno_Id",
                table: "Nota",
                column: "Aluno_Id",
                principalTable: "Aluno",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Aluno_Aluno_Id",
                table: "Nota");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropIndex(
                name: "IX_Nota_Aluno_Id",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "Aluno_Id",
                table: "Nota");
        }
    }
}
