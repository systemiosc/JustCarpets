using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JustCarpets.Migrations
{
    public partial class cuystomeredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MacAddress",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "MacAddress",
                table: "Customer");
        }
    }
}
