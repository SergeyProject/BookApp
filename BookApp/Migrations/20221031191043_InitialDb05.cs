using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Migrations
{
    public partial class InitialDb05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Books",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "ReservBookId",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReservBookId",
                table: "Books",
                column: "ReservBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ReservBooks_ReservBookId",
                table: "Books",
                column: "ReservBookId",
                principalTable: "ReservBooks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ReservBooks_ReservBookId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ReservBookId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReservBookId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
