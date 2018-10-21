using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfflineMessagingAPI.Migrations
{
    public partial class UpdateChatsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReceiverDelete",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "IsSenderDelete",
                table: "Chats");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiverDeleteTime",
                table: "Chats",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SenderDeleteTime",
                table: "Chats",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverDeleteTime",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "SenderDeleteTime",
                table: "Chats");

            migrationBuilder.AddColumn<bool>(
                name: "IsReceiverDelete",
                table: "Chats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSenderDelete",
                table: "Chats",
                nullable: false,
                defaultValue: false);
        }
    }
}
