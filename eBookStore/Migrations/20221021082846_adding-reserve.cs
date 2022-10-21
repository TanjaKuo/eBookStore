using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Migrations
{
    public partial class addingreserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reserves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserves_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_BookId",
                table: "Reserves",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserves");
        }
    }
}
