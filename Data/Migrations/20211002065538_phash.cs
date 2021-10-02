using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class phash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashSalt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashSalt",
                table: "Users");
        }
    }
}
