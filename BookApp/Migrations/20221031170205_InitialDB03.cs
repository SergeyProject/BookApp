using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Migrations
{
    public partial class InitialDB03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "ReservBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservBooks_BookId",
                table: "ReservBooks",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservBooks");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
