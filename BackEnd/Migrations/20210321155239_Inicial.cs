using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiante");
        }
    }
}
