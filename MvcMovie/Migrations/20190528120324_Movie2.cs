using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class Movie2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Movie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Movie");
        }
    }
}
