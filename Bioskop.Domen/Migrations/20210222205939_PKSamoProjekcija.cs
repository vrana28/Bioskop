using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioskop.Domen.Migrations
{
    public partial class PKSamoProjekcija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Projekcija_ProjekcijaId1_ProjekcijaFilmId_ProjekcijaSalaId",
                table: "Karta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projekcija",
                table: "Projekcija");

            migrationBuilder.DropIndex(
                name: "IX_Karta_ProjekcijaId1_ProjekcijaFilmId_ProjekcijaSalaId",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "ProjekcijaFilmId",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "ProjekcijaId1",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "ProjekcijaSalaId",
                table: "Karta");

            migrationBuilder.AlterColumn<int>(
                name: "ProjekcijaId",
                table: "Projekcija",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projekcija",
                table: "Projekcija",
                column: "ProjekcijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_ProjekcijaId",
                table: "Karta",
                column: "ProjekcijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Projekcija_ProjekcijaId",
                table: "Karta",
                column: "ProjekcijaId",
                principalTable: "Projekcija",
                principalColumn: "ProjekcijaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Projekcija_ProjekcijaId",
                table: "Karta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projekcija",
                table: "Projekcija");

            migrationBuilder.DropIndex(
                name: "IX_Karta_ProjekcijaId",
                table: "Karta");

            migrationBuilder.AlterColumn<int>(
                name: "ProjekcijaId",
                table: "Projekcija",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProjekcijaFilmId",
                table: "Karta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjekcijaId1",
                table: "Karta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjekcijaSalaId",
                table: "Karta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projekcija",
                table: "Projekcija",
                columns: new[] { "ProjekcijaId", "FilmId", "SalaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Karta_ProjekcijaId1_ProjekcijaFilmId_ProjekcijaSalaId",
                table: "Karta",
                columns: new[] { "ProjekcijaId1", "ProjekcijaFilmId", "ProjekcijaSalaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Projekcija_ProjekcijaId1_ProjekcijaFilmId_ProjekcijaSalaId",
                table: "Karta",
                columns: new[] { "ProjekcijaId1", "ProjekcijaFilmId", "ProjekcijaSalaId" },
                principalTable: "Projekcija",
                principalColumns: new[] { "ProjekcijaId", "FilmId", "SalaId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
