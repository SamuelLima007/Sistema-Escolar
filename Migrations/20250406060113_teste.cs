using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNotas.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Administratores",
                table: "Administratores");

            migrationBuilder.RenameTable(
                name: "Administratores",
                newName: "Administrators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administrators",
                table: "Administrators",
                column: "AdministratorId");

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    MyTaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Subject_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Class_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.MyTaskId);
                    table.ForeignKey(
                        name: "FK_Task_Class_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_Subject_Subject_Id",
                        column: x => x.Subject_Id,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_Class_Id",
                table: "Task",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Subject_Id",
                table: "Task",
                column: "Subject_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Administrators",
                table: "Administrators");

            migrationBuilder.RenameTable(
                name: "Administrators",
                newName: "Administratores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administratores",
                table: "Administratores",
                column: "AdministratorId");
        }
    }
}
