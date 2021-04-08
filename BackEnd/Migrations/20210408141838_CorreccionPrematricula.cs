using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class CorreccionPrematricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelacionUR");

            migrationBuilder.DropColumn(
                name: "IdEstudiante",
                table: "Responsable");

            migrationBuilder.RenameColumn(
                name: "IdPrematricula",
                table: "Responsable",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "IdResponsable",
                table: "PreMatricula",
                newName: "IdUsuario");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Estudiante",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Estudiante");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Responsable",
                newName: "IdPrematricula");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "PreMatricula",
                newName: "IdResponsable");

            migrationBuilder.AddColumn<int>(
                name: "IdEstudiante",
                table: "Responsable",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
