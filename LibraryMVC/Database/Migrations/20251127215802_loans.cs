using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class loans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookLoans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    DateLoaned = table.Column<DateOnly>(type: "date", nullable: false),
                    LoanPeriodDays = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateOnly>(type: "date", nullable: false),
                    isReturned = table.Column<bool>(type: "bit", nullable: false),
                    isCancelled = table.Column<bool>(type: "bit", nullable: false),
                    isExtended = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookLoans_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_BookID",
                table: "BookLoans",
                column: "BookID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLoans");
        }
    }
}
