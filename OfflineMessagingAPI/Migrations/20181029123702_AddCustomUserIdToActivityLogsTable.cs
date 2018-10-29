using Microsoft.EntityFrameworkCore.Migrations;

namespace OfflineMessagingAPI.Migrations
{
    public partial class AddCustomUserIdToActivityLogsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customUserID",
                table: "ActivityLogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_customUserID",
                table: "ActivityLogs",
                column: "customUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLogs_CustomUser_customUserID",
                table: "ActivityLogs",
                column: "customUserID",
                principalTable: "CustomUser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLogs_CustomUser_customUserID",
                table: "ActivityLogs");

            migrationBuilder.DropIndex(
                name: "IX_ActivityLogs_customUserID",
                table: "ActivityLogs");

            migrationBuilder.DropColumn(
                name: "customUserID",
                table: "ActivityLogs");
        }
    }
}
