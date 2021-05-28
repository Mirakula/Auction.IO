using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.IO.EntityFramework.Migrations
{
    public partial class IspravkaGreskeAdministrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "UserRole",
                keyValue: 1,
                column: "SystemRole",
                value: "Administrator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "UserRole",
                keyValue: 1,
                column: "SystemRole",
                value: "Adminstrator");
        }
    }
}
