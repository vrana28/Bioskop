using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioskop.Domen.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "SalaId", "NazivSale", "Slobodna" },
                values: new object[] { 1, "Sala Marilyn Monroe", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sala",
                keyColumn: "SalaId",
                keyValue: 1);
        }
    }
}
