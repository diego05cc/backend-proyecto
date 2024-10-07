using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_proyecto.Migrations
{
    /// <inheritdoc />
    public partial class task2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "usuarios",
                table: "tasks",
                newName: "user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user",
                table: "tasks",
                newName: "usuarios");
        }
    }
}
