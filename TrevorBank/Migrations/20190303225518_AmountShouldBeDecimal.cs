using Microsoft.EntityFrameworkCore.Migrations;

namespace TrevorBank.Migrations
{
    public partial class AmountShouldBeDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Addresses",
                newName: "Zipcode");

            migrationBuilder.AlterColumn<decimal>(
                name: "DollarAmount",
                table: "Checks",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "Addresses",
                newName: "ZipCode");

            migrationBuilder.AlterColumn<int>(
                name: "DollarAmount",
                table: "Checks",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
