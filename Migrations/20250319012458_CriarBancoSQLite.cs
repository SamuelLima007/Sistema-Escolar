using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNotas.Migrations
{
    /// <inheritdoc />
    public partial class CriarBancoSQLite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    AdministradorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.AdministradorId);
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    ClasseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Serie = table.Column<string>(type: "Text", maxLength: 30, nullable: false),
                    Turma = table.Column<string>(type: "Text", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.ClasseId);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "Text", maxLength: 30, nullable: false),
                    Idade = table.Column<int>(type: "Text", maxLength: 2, nullable: false),
                    Email = table.Column<string>(type: "Text", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "Text", maxLength: 30, nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorId);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Idade = table.Column<int>(type: "INT", maxLength: 2, nullable: false),
                    Classe_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Roles = table.Column<string>(type: "Text", maxLength: 20, nullable: false),
                    Nome = table.Column<string>(type: "Text", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "Text", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NText", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_ALUNO",
                        column: x => x.Classe_Id,
                        principalTable: "Classe",
                        principalColumn: "ClasseId");
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "Text", maxLength: 30, nullable: false),
                    ClasseId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.DisciplinaId);
                    table.ForeignKey(
                        name: "FK_Disciplina_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "ClasseId");
                });

            migrationBuilder.CreateTable(
                name: "ClasseProfessor",
                columns: table => new
                {
                    ClasseId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "AlunoDisciplina",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplina", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId");
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "DisciplinaId");
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    NotaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<double>(type: "decimal(2, 2)", maxLength: 4, nullable: false),
                    Disciplina_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Aluno_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.NotaId);
                    table.ForeignKey(
                        name: "FK_NOTA",
                        column: x => x.Disciplina_Id,
                        principalTable: "Disciplina",
                        principalColumn: "DisciplinaId");
                    table.ForeignKey(
                        name: "FK_Nota_Aluno_Aluno_Id",
                        column: x => x.Aluno_Id,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AlunoDisciplina_DisciplinaId",
                table: "AlunoDisciplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasseProfessor_ProfessorId",
                table: "ClasseProfessor",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ClasseId",
                table: "Disciplina",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_Nome",
                table: "Disciplina",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nota_Aluno_Id",
                table: "Nota",
                column: "Aluno_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_Disciplina_Id",
                table: "Nota",
                column: "Disciplina_Id");

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
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "AlunoDisciplina");

            migrationBuilder.DropTable(
                name: "ClasseProfessor");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Classe");
        }
    }
}
