using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrevorBank.Migrations
{
    public partial class BetterNameForCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checks_Customers_IdCustomer",
                table: "Checks");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.CreateTable(
                name: "BankingClients",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PrimaryAddressIdAddress = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankingClients", x => x.IdCustomer);
                    table.ForeignKey(
                        name: "FK_BankingClients_Addresses_PrimaryAddressIdAddress",
                        column: x => x.PrimaryAddressIdAddress,
                        principalTable: "Addresses",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankingClients_PrimaryAddressIdAddress",
                table: "BankingClients",
                column: "PrimaryAddressIdAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_BankingClients_IdCustomer",
                table: "Checks",
                column: "IdCustomer",
                principalTable: "BankingClients",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checks_BankingClients_IdCustomer",
                table: "Checks");

            migrationBuilder.DropTable(
                name: "BankingClients");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    PrimaryAddressIdAddress = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IdCustomer);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_PrimaryAddressIdAddress",
                        column: x => x.PrimaryAddressIdAddress,
                        principalTable: "Addresses",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PrimaryAddressIdAddress",
                table: "Customers",
                column: "PrimaryAddressIdAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_Customers_IdCustomer",
                table: "Checks",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
