using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Migrations
{
    public partial class InitialDB02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Books",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Books");
        }
    }
}
