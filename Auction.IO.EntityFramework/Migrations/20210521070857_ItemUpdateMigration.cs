using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.IO.EntityFramework.Migrations
{
    public partial class ItemUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LastBidPrice",
                table: "Items",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "LastBidder",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Ticker",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastBidPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LastBidder",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Ticker",
                table: "Items");
        }
    }
}
