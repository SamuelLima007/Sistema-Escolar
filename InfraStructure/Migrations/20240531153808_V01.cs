using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNotas.Migrations
{
    /// <inheritdoc />
    public partial class V01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    ClasseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serie = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Turma = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.ClasseId);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Idade = table.Column<int>(type: "INT", maxLength: 2, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorId);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Idade = table.Column<int>(type: "INT", maxLength: 2, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    Roles = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Classe_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_ALUNO_CLASSE",
                        column: x => x.Classe_Id,
                        principalTable: "Classe",
                        principalColumn: "ClasseId");
                });

            migrationBuilder.CreateTable(
                name: "ClasseProfessor",
                columns: table => new
                {
                    ClasseId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseProfessor", x => new { x.ClasseId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_ClasseProfessor_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "ClasseId");
                    table.ForeignKey(
                        name: "FK_ClasseProfessor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Classe_Id",
                table: "Aluno",
                column: "Classe_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Email",
                table: "Aluno",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClasseProfessor_ProfessorId",
                table: "ClasseProfessor",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_Email",
                table: "Professor",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "ClasseProfessor");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
