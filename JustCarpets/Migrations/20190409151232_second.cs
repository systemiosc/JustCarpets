using Microsoft.EntityFrameworkCore.Migrations;

namespace JustCarpets.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "InstallerReviewId",
                table: "CustomerOrder",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "InstallerDate",
                table: "CustomerOrder",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "InstallerReviewId",
                table: "CustomerOrder",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstallerDate",
                table: "CustomerOrder",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
