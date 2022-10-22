using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Migrations
{
    public partial class addingbookingNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookingNumber",
                table: "Book",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingNumber",
                table: "Book");
        }
    }
}
