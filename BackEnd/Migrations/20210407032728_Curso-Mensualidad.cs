using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class CursoMensualidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPrematricula",
                table: "Responsable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreMatriculaId",
                table: "Responsable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "estudianteId",
                table: "PreMatricula",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxEstudiantes = table.Column<int>(type: "int", nullable: false),
                    IdDirectorDocente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensualidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaPago = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorMensualidad = table.Column<double>(type: "float", nullable: false),
                    DescuentoMensualidad = table.Column<double>(type: "float", nullable: false),
                    Abono = table.Column<double>(type: "float", nullable: false),
                    Deuda = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMatricula = table.Column<int>(type: "int", nullable: false),
                    TotalMensualidad = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensualidad", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responsable_PreMatriculaId",
                table: "Responsable",
                column: "PreMatriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PreMatricula_estudianteId",
                table: "PreMatricula",
                column: "estudianteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreMatricula_Estudiante_estudianteId",
                table: "PreMatricula",
                column: "estudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_PreMatricula_PreMatriculaId",
                table: "Responsable",
                column: "PreMatriculaId",
                principalTable: "PreMatricula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreMatricula_Estudiante_estudianteId",
                table: "PreMatricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_PreMatricula_PreMatriculaId",
                table: "Responsable");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Mensualidad");

            migrationBuilder.DropIndex(
                name: "IX_Responsable_PreMatriculaId",
                table: "Responsable");

            migrationBuilder.DropIndex(
                name: "IX_PreMatricula_estudianteId",
                table: "PreMatricula");

            migrationBuilder.DropColumn(
                name: "IdPrematricula",
                table: "Responsable");

            migrationBuilder.DropColumn(
                name: "PreMatriculaId",
                table: "Responsable");

            migrationBuilder.DropColumn(
                name: "estudianteId",
                table: "PreMatricula");
        }
    }
}
