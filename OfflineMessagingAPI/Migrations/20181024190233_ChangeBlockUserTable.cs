using Microsoft.EntityFrameworkCore.Migrations;

namespace OfflineMessagingAPI.Migrations
{
    public partial class ChangeBlockUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockUser_CustomUser_BlockingUserID",
                table: "BlockUser");

            migrationBuilder.RenameColumn(
                name: "BlockingUserID",
                table: "BlockUser",
                newName: "BlockerUserID");

            migrationBuilder.RenameIndex(
                name: "IX_BlockUser_BlockingUserID",
                table: "BlockUser",
                newName: "IX_BlockUser_BlockerUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockUser_CustomUser_BlockerUserID",
                table: "BlockUser",
                column: "BlockerUserID",
                principalTable: "CustomUser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockUser_CustomUser_BlockerUserID",
                table: "BlockUser");

            migrationBuilder.RenameColumn(
                name: "BlockerUserID",
                table: "BlockUser",
                newName: "BlockingUserID");

            migrationBuilder.RenameIndex(
                name: "IX_BlockUser_BlockerUserID",
                table: "BlockUser",
                newName: "IX_BlockUser_BlockingUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockUser_CustomUser_BlockingUserID",
                table: "BlockUser",
                column: "BlockingUserID",
                principalTable: "CustomUser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
