using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_proyecto.Migrations
{
    /// <inheritdoc />
    public partial class task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_incio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    progreso = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");
        }
    }
}
