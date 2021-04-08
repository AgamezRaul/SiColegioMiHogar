using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Estudiante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdeEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FecNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LugNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LugExpedicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsProcedencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirResidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelEstudiante = table.Column<double>(type: "float", nullable: false),
                    TipSangre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradoEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FecConfirmacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdePreMatricula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "RelacionUR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdResponsable = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacionUR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreMatricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FecPrematricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdResponsable = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estudianteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreMatricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreMatricula_Estudiante_estudianteId",
                        column: x => x.estudianteId,
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Responsable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdeResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FecNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LugNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LugExpedicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelResponsable = table.Column<int>(type: "int", nullable: false),
                    ProfResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OcuResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelEmpresa = table.Column<int>(type: "int", nullable: false),
                    TipoResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acudiente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    IdPrematricula = table.Column<int>(type: "int", nullable: false),
                    PreMatriculaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsable_PreMatricula_PreMatriculaId",
                        column: x => x.PreMatriculaId,
                        principalTable: "PreMatricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreMatricula_estudianteId",
                table: "PreMatricula",
                column: "estudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsable_PreMatriculaId",
                table: "Responsable",
                column: "PreMatriculaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Mensualidad");

            migrationBuilder.DropTable(
                name: "RelacionUR");

            migrationBuilder.DropTable(
                name: "Responsable");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "PreMatricula");

            migrationBuilder.DropTable(
                name: "Estudiante");
        }
    }
}
