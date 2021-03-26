using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class tablasSprint1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PreMatricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FecPrematricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdResponsable = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreMatricula", x => x.Id);
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
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "PreMatricula");

            migrationBuilder.DropTable(
                name: "RelacionUR");

            migrationBuilder.DropTable(
                name: "Responsable");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
