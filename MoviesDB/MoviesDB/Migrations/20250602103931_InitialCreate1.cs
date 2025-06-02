using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Actors_CastID",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "Casts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Casts",
                table: "Casts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Casts_CastID",
                table: "Movies",
                column: "CastID",
                principalTable: "Casts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Casts_CastID",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Casts",
                table: "Casts");

            migrationBuilder.RenameTable(
                name: "Casts",
                newName: "Actors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Actors_CastID",
                table: "Movies",
                column: "CastID",
                principalTable: "Actors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
