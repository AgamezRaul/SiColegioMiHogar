using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class actividad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "IdMateria",
                table: "Nota");

            migrationBuilder.RenameColumn(
                name: "IdPeriodo",
                table: "Nota",
                newName: "IdActividad");

            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Porcentaje = table.Column<double>(type: "float", nullable: false),
                    IdMateria = table.Column<int>(type: "int", nullable: false),
                    IdPeriodo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Periodo",
                columns: new[] { "Id", "FechaFin", "FechaInicio", "NombrePeriodo", "NumeroPeriodo" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Local), "Primer Periodo", 1 },
                    { 2, new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), "Segundo Periodo", 2 },
                    { 3, new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Local), "Tercer Periodo", 3 },
                    { 4, new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), "Cuarto Periodo", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DeleteData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "IdActividad",
                table: "Nota",
                newName: "IdPeriodo");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Nota",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMateria",
                table: "Nota",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
