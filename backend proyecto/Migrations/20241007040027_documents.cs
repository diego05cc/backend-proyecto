using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_proyecto.Migrations
{
    /// <inheritdoc />
    public partial class documents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tasks",
                table: "tasks");

            migrationBuilder.RenameTable(
                name: "tasks",
                newName: "Task");

            migrationBuilder.AddColumn<int>(
                name: "TaskId1",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskIdId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Task",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_users_TaskId1",
                table: "users",
                column: "TaskId1");

            migrationBuilder.CreateIndex(
                name: "IX_users_TaskIdId",
                table: "users",
                column: "TaskIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Userid",
                table: "Task",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_users_Userid",
                table: "Task",
                column: "Userid",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Task_TaskId1",
                table: "users",
                column: "TaskId1",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Task_TaskIdId",
                table: "users",
                column: "TaskIdId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_users_Userid",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Task_TaskId1",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Task_TaskIdId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_TaskId1",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_TaskIdId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_Userid",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskId1",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TaskIdId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "tasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tasks",
                table: "tasks",
                column: "Id");
        }
    }
}
