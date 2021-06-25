using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioskop.Domen.Migrations
{
    public partial class DodatoSediste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slobodna",
                table: "Sala");

            migrationBuilder.UpdateData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 1,
                columns: new[] { "OpisFilma", "PutanjaBackPostera", "PutanjaPostera", "YoutubeTrailer" },
                values: new object[] { "Shrek is an anti-social and highly-territorial green ogre who loves the solitude of his swamp. His life is interrupted after the vertically challenged Lord Farquaad of Duloc exiles multiple fairy-tale creatures to Shrek's swamp. Angered by the intrusion, he decides to pay Farquaad a visit and demand they be moved elsewhere. He reluctantly allows the talkative Donkey, who was exiled as well, to tag along and guide him to Duloc.", "https://cdn.britannica.com/51/93451-050-4C57C2D5/Shrek-sidekick-Donkey.jpg", "https://upload.wikimedia.org/wikipedia/en/3/39/Shrek.jpg", "https://www.youtube.com/watch?v=CwXOrWvPBPk&ab_channel=MovieclipsClassicTrailers" });

            migrationBuilder.UpdateData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 2,
                columns: new[] { "OpisFilma", "PutanjaBackPostera", "PutanjaPostera", "YoutubeTrailer" },
                values: new object[] { "The Dragon Warrior has to clash against the savage Tai Lung as China's fate hangs in the balance. However, the Dragon Warrior mantle is supposedly mistaken to be bestowed upon an obese panda who is a novice in martial arts.", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/68/Kung_Fu_Panda_logo.svg/1920px-Kung_Fu_Panda_logo.svg.png", "https://images-na.ssl-images-amazon.com/images/I/517M%2BF7msHL.jpg", "https://www.youtube.com/watch?v=PXi3Mv6KMzY&ab_channel=TrailersPlaygroundHD" });

            migrationBuilder.UpdateData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 3,
                columns: new[] { "OpisFilma", "PutanjaBackPostera", "PutanjaPostera", "YoutubeTrailer" },
                values: new object[] { "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "https://www.hollywoodinsider.com/wp-content/uploads/2020/01/Hollywood-Insider-Feature-Inception-Greatest-Movie-Of-The-Decade-Leonardo-Dicaprio-Tom-Hardy-Marion-Cotillard-Joseph-Gordon-Levitt-Michael-Caine-Christopher-Nolan-Ken-Wantanabe-Ellen-Paige.jpg", "https://resizing.flixster.com/4MrL62heb7yBgBt8zllSeqNZxg4=/206x305/v2/https://flxt.tmsimg.com/assets/p7825626_p_v10_af.jpg", "https://www.youtube.com/watch?v=YoHD9XEInc0&ab_channel=MovieclipsClassicTrailers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Slobodna",
                table: "Sala",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 1,
                columns: new[] { "OpisFilma", "PutanjaBackPostera", "PutanjaPostera", "YoutubeTrailer" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 2,
                columns: new[] { "OpisFilma", "PutanjaBackPostera", "PutanjaPostera", "YoutubeTrailer" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 3,
                columns: new[] { "OpisFilma", "PutanjaBackPostera", "PutanjaPostera", "YoutubeTrailer" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Sala",
                keyColumn: "SalaId",
                keyValue: 1,
                column: "Slobodna",
                value: true);
        }
    }
}
