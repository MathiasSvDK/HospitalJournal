using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorIdentityServerTest.Migrations.Journal
{
    public partial class pageidrename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "page_id",
                table: "journal_approve",
                newName: "journal_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "journal_id",
                table: "journal_approve",
                newName: "page_id");
        }
    }
}
