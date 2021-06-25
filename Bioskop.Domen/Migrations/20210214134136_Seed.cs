using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioskop.Domen.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vreme",
                table: "Film");

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "FilmId", "Godina", "Naziv", "Reziser", "Trajanje", "Zanr" },
                values: new object[] { 1, 2001, "Shrek", " Andrew Adamson", 93, 0 });

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "FilmId", "Godina", "Naziv", "Reziser", "Trajanje", "Zanr" },
                values: new object[] { 2, 2008, "Kung Fu Panda", " Mark Osborne", 92, 2 });

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "FilmId", "Godina", "Naziv", "Reziser", "Trajanje", "Zanr" },
                values: new object[] { 3, 2010, "Inception", " Christopher Nolan", 93, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 3);

            migrationBuilder.AddColumn<DateTime>(
                name: "Vreme",
                table: "Film",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
