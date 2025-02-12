using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _VideoRentalShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "RentalHeader",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalHeader_MovieId",
                table: "RentalHeader",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalHeader_Movie_MovieId",
                table: "RentalHeader",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalHeader_Movie_MovieId",
                table: "RentalHeader");

            migrationBuilder.DropIndex(
                name: "IX_RentalHeader_MovieId",
                table: "RentalHeader");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "RentalHeader");
        }
    }
}
