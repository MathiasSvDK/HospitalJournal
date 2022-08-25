using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorIdentityServerTest.Migrations.Journal
{
    public partial class JournalApproveapprovedvariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "journal_approve",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "journal_approve");
        }
    }
}
