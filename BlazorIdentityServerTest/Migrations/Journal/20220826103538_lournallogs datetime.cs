using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorIdentityServerTest.Migrations.Journal
{
    public partial class lournallogsdatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "JournalLogs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "JournalLogs");
        }
    }
}
