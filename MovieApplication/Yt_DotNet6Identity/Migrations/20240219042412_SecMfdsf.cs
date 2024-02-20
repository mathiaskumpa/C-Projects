using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Migrations
{
    /// <inheritdoc />
    public partial class SecMfdsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Votes_MovieId",
                table: "Votes",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Movies_MovieId",
                table: "Votes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Movies_MovieId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_MovieId",
                table: "Votes");
        }
    }
}
