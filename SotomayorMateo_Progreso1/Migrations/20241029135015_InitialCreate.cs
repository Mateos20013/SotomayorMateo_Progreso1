using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SotomayorMateo_Progreso1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    PerezId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sotomayor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Ingresos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CelularId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sotomayor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sotomayor_Celular_CelularId",
                        column: x => x.CelularId,
                        principalTable: "Celular",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sotomayor_CelularId",
                table: "Sotomayor",
                column: "CelularId",
                unique: true,
                filter: "[CelularId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sotomayor");

            migrationBuilder.DropTable(
                name: "Celular");
        }
    }
}
