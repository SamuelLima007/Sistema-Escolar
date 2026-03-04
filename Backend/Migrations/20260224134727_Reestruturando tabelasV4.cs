using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNotas.Migrations
{
    /// <inheritdoc />
    public partial class ReestruturandotabelasV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "AcademicPeriods",
                type: "character varying(48)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "AcademicPeriods",
                type: "character varying(48)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "AcademicPeriods",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(48)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "AcademicPeriods",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(48)");
        }
    }
}
