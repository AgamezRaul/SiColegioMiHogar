using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class correccion_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificacion",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimerApellido",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimerNombre",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoApellido",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoNombre",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2021, 6, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2021, 7, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 7, 22, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificacion",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PrimerApellido",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PrimerNombre",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "SegundoApellido",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "SegundoNombre",
                table: "Usuario");

            migrationBuilder.UpdateData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Periodo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 23, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
