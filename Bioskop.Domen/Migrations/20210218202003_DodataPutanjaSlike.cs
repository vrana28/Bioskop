using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioskop.Domen.Migrations
{
    public partial class DodataPutanjaSlike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PutanjaBackPostera",
                table: "Film",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PutanjaPostera",
                table: "Film",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PutanjaBackPostera",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "PutanjaPostera",
                table: "Film");
        }
    }
}
