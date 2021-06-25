using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioskop.Domen.Migrations.Korisnik
{
    public partial class DodatEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Korisnik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Korisnik");
        }
    }
}
