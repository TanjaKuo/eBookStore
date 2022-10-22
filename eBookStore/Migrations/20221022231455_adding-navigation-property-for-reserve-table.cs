using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Migrations
{
    public partial class addingnavigationpropertyforreservetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReserveId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ReserveId",
                table: "User",
                column: "ReserveId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Reserves_ReserveId",
                table: "User",
                column: "ReserveId",
                principalTable: "Reserves",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Reserves_ReserveId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ReserveId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ReserveId",
                table: "User");
        }
    }
}
