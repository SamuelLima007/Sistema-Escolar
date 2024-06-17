using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNotas.Migrations
{
    /// <inheritdoc />
    public partial class v100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoDisciplina_AlunoId",
                table: "AlunoDisciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunoDisciplina_DisciplinaId",
                table: "AlunoDisciplina");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoDisciplina_AlunoId",
                table: "AlunoDisciplina",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoDisciplina_DisciplinaId",
                table: "AlunoDisciplina",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "DisciplinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoDisciplina_AlunoId",
                table: "AlunoDisciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunoDisciplina_DisciplinaId",
                table: "AlunoDisciplina");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoDisciplina_AlunoId",
                table: "AlunoDisciplina",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoDisciplina_DisciplinaId",
                table: "AlunoDisciplina",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "DisciplinaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
