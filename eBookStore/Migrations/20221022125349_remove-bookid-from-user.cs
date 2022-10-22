using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Migrations
{
    public partial class removebookidfromuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Book_BookId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_BookId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_User_BookId",
                table: "User",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Book_BookId",
                table: "User",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
