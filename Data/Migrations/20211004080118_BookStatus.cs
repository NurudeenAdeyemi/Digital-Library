using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class BookStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Books",
                newName: "AvailabilityStatus");

            migrationBuilder.AddColumn<int>(
                name: "AccessibilityStatus",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessibilityStatus",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "AvailabilityStatus",
                table: "Books",
                newName: "Status");
        }
    }
}
