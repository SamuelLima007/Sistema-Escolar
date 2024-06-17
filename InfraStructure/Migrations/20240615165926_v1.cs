using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNotas.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ALUNO_CLASSE",
                table: "Aluno");

            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "Professor",
                newName: "Role");

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    DisciplinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    ClasseId = table.Column<int>(type: "int", nullable: true)
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
                name: "AlunoDisciplina",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplina", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "DisciplinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    NotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(2,2)", maxLength: 4, nullable: false),
                    Disciplina_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.NotaId);
                    table.ForeignKey(
                        name: "FK_NOTA",
                        column: x => x.Disciplina_Id,
                        principalTable: "Disciplina",
                        principalColumn: "DisciplinaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplina_DisciplinaId",
                table: "AlunoDisciplina",
                column: "DisciplinaId");

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
                name: "IX_Nota_Disciplina_Id",
                table: "Nota",
                column: "Disciplina_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ALUNO",
                table: "Aluno",
                column: "Classe_Id",
                principalTable: "Classe",
                principalColumn: "ClasseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ALUNO",
                table: "Aluno");

            migrationBuilder.DropTable(
                name: "AlunoDisciplina");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Professor",
                newName: "Roles");

            migrationBuilder.AddForeignKey(
                name: "FK_ALUNO_CLASSE",
                table: "Aluno",
                column: "Classe_Id",
                principalTable: "Classe",
                principalColumn: "ClasseId");
        }
    }
}
