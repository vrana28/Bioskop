using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Domen
{
    public class BioskopContext : DbContext
    {
        // pravimo entitete
        // DbSet najznacajnija klasa
        public DbSet<Film> Film{ get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Projekcija> Projekcija{ get; set; }
        public DbSet<Sediste> Sediste{ get; set; }
        public DbSet<Karta> Karta{ get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory
         = LoggerFactory.Create(builder => { builder.AddConsole(); });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Bioskop;");
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Bioskop;");
         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Sala>().OwnsMany(s => s.SedistaUSali);
            // FLUENT Api - za podesavanje slozenog kljuca // aspcijativni niz - dole
            modelBuilder.Entity<Projekcija>(p =>
            {
                p.HasKey(p => new { p.ProjekcijaId });
                //p.HasOne(p => p.Film).WithMany(f => f.Sale).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Ignore<Image>();
            //modelBuilder.Entity<Student>().Ignore(s=>s.LastName);
            //modelBuilder.Ignore<Student>();

            Seed(modelBuilder);

        }
        // za postavljanje pocetnih vrednosti podataka u bazi
        // mora ekplicitno da se doda ID
        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasData(
                new Film {FilmId=1, Naziv = "Shrek", Godina = 2001, Trajanje = 93, Reziser = " Andrew Adamson", Zanr = Zanr.Komedija,
                PutanjaBackPostera= "https://cdn.britannica.com/51/93451-050-4C57C2D5/Shrek-sidekick-Donkey.jpg",
                    PutanjaPostera= "https://upload.wikimedia.org/wikipedia/en/3/39/Shrek.jpg",
                    YoutubeTrailer= "https://www.youtube.com/watch?v=CwXOrWvPBPk&ab_channel=MovieclipsClassicTrailers",
                    OpisFilma= "Shrek is an anti-social and highly-territorial green ogre who loves the solitude of his swamp. His life is interrupted after the vertically challenged Lord Farquaad of Duloc exiles multiple fairy-tale creatures to Shrek's swamp. Angered by the intrusion, he decides to pay Farquaad a visit and demand they be moved elsewhere. He reluctantly allows the talkative Donkey, who was exiled as well, to tag along and guide him to Duloc."
                },
                new Film {FilmId=2, Naziv = "Kung Fu Panda", Godina = 2008, Trajanje = 92, Reziser = " Mark Osborne", Zanr = Zanr.Animirani,
                    PutanjaBackPostera = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/68/Kung_Fu_Panda_logo.svg/1920px-Kung_Fu_Panda_logo.svg.png",
                    PutanjaPostera = "https://images-na.ssl-images-amazon.com/images/I/517M%2BF7msHL.jpg",
                    YoutubeTrailer = "https://www.youtube.com/watch?v=PXi3Mv6KMzY&ab_channel=TrailersPlaygroundHD",
                    OpisFilma = "The Dragon Warrior has to clash against the savage Tai Lung as China's fate hangs in the balance. However, the Dragon Warrior mantle is supposedly mistaken to be bestowed upon an obese panda who is a novice in martial arts."
                },
                new Film { FilmId=3, Naziv = "Inception", Godina = 2010, Trajanje = 93, Reziser = " Christopher Nolan", Zanr = Zanr.Akcija,
                    PutanjaBackPostera = "https://www.hollywoodinsider.com/wp-content/uploads/2020/01/Hollywood-Insider-Feature-Inception-Greatest-Movie-Of-The-Decade-Leonardo-Dicaprio-Tom-Hardy-Marion-Cotillard-Joseph-Gordon-Levitt-Michael-Caine-Christopher-Nolan-Ken-Wantanabe-Ellen-Paige.jpg",
                    PutanjaPostera = "https://resizing.flixster.com/4MrL62heb7yBgBt8zllSeqNZxg4=/206x305/v2/https://flxt.tmsimg.com/assets/p7825626_p_v10_af.jpg",
                    YoutubeTrailer = "https://www.youtube.com/watch?v=YoHD9XEInc0&ab_channel=MovieclipsClassicTrailers",
                    OpisFilma = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O."
                }
                );
            modelBuilder.Entity<Sala>().HasData(
                new Sala { SalaId=1,NazivSale="Sala Marilyn Monroe",SedistaUSali = new List<Sediste> { } }
                );
            
        }
    }
}
