using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioskop.Domen.Migrations
{
    public partial class DodatPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projekcija_Film_FilmId",
                table: "Projekcija");

            migrationBuilder.AddForeignKey(
                name: "FK_Projekcija_Film_FilmId",
                table: "Projekcija",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projekcija_Film_FilmId",
                table: "Projekcija");

            migrationBuilder.AddForeignKey(
                name: "FK_Projekcija_Film_FilmId",
                table: "Projekcija",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
