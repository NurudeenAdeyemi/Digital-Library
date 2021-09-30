using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class secg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashSalt",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashSalt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
