using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioskop.Domen.Migrations
{
    public partial class DodatKrajProjekcije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "VremeKrajaProjekcije",
                table: "Projekcija",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VremeKrajaProjekcije",
                table: "Projekcija");
        }
    }
}
