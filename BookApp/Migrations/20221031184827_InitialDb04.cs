using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Migrations
{
    public partial class InitialDb04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservBooks_Books_BookId",
                table: "ReservBooks");

            migrationBuilder.DropIndex(
                name: "IX_ReservBooks_BookId",
                table: "ReservBooks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReservBooks_BookId",
                table: "ReservBooks",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservBooks_Books_BookId",
                table: "ReservBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
