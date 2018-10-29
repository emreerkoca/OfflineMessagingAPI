using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfflineMessagingAPI.Migrations
{
    public partial class CorrectionActivityTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ActivityTime",
                table: "ActivityLogs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ActivityTime",
                table: "ActivityLogs",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
