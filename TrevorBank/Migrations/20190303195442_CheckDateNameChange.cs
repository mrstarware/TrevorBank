using Microsoft.EntityFrameworkCore.Migrations;

namespace TrevorBank.Migrations
{
    public partial class CheckDateNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Checks",
                newName: "CheckDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckDate",
                table: "Checks",
                newName: "Date");
        }
    }
}
