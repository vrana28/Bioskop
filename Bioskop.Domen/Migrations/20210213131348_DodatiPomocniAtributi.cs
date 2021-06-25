using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioskop.Domen.Migrations
{
    public partial class DodatiPomocniAtributi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Korisnik_KorisnikId",
                table: "Karta");

            migrationBuilder.DropForeignKey(
                name: "FK_Sediste_Sala_SalaId",
                table: "Sediste");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Sediste",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Karta",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Korisnik_KorisnikId",
                table: "Karta",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sediste_Sala_SalaId",
                table: "Sediste",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "SalaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Korisnik_KorisnikId",
                table: "Karta");

            migrationBuilder.DropForeignKey(
                name: "FK_Sediste_Sala_SalaId",
                table: "Sediste");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Sediste",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Karta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Korisnik_KorisnikId",
                table: "Karta",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sediste_Sala_SalaId",
                table: "Sediste",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "SalaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
