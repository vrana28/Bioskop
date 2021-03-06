﻿// <auto-generated />
using System;
using Bioskop.Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bioskop.Domen.Migrations
{
    [DbContext(typeof(BioskopContext))]
    [Migration("20210222225603_DodatoSediste")]
    partial class DodatoSediste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bioskop.Domen.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Godina")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpisFilma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PutanjaBackPostera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PutanjaPostera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reziser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Trajanje")
                        .HasColumnType("int");

                    b.Property<string>("YoutubeTrailer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zanr")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.ToTable("Film");

                    b.HasData(
                        new
                        {
                            FilmId = 1,
                            Godina = 2001,
                            Naziv = "Shrek",
                            OpisFilma = "Shrek is an anti-social and highly-territorial green ogre who loves the solitude of his swamp. His life is interrupted after the vertically challenged Lord Farquaad of Duloc exiles multiple fairy-tale creatures to Shrek's swamp. Angered by the intrusion, he decides to pay Farquaad a visit and demand they be moved elsewhere. He reluctantly allows the talkative Donkey, who was exiled as well, to tag along and guide him to Duloc.",
                            PutanjaBackPostera = "https://cdn.britannica.com/51/93451-050-4C57C2D5/Shrek-sidekick-Donkey.jpg",
                            PutanjaPostera = "https://upload.wikimedia.org/wikipedia/en/3/39/Shrek.jpg",
                            Reziser = " Andrew Adamson",
                            Trajanje = 93,
                            YoutubeTrailer = "https://www.youtube.com/watch?v=CwXOrWvPBPk&ab_channel=MovieclipsClassicTrailers",
                            Zanr = 0
                        },
                        new
                        {
                            FilmId = 2,
                            Godina = 2008,
                            Naziv = "Kung Fu Panda",
                            OpisFilma = "The Dragon Warrior has to clash against the savage Tai Lung as China's fate hangs in the balance. However, the Dragon Warrior mantle is supposedly mistaken to be bestowed upon an obese panda who is a novice in martial arts.",
                            PutanjaBackPostera = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/68/Kung_Fu_Panda_logo.svg/1920px-Kung_Fu_Panda_logo.svg.png",
                            PutanjaPostera = "https://images-na.ssl-images-amazon.com/images/I/517M%2BF7msHL.jpg",
                            Reziser = " Mark Osborne",
                            Trajanje = 92,
                            YoutubeTrailer = "https://www.youtube.com/watch?v=PXi3Mv6KMzY&ab_channel=TrailersPlaygroundHD",
                            Zanr = 2
                        },
                        new
                        {
                            FilmId = 3,
                            Godina = 2010,
                            Naziv = "Inception",
                            OpisFilma = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                            PutanjaBackPostera = "https://www.hollywoodinsider.com/wp-content/uploads/2020/01/Hollywood-Insider-Feature-Inception-Greatest-Movie-Of-The-Decade-Leonardo-Dicaprio-Tom-Hardy-Marion-Cotillard-Joseph-Gordon-Levitt-Michael-Caine-Christopher-Nolan-Ken-Wantanabe-Ellen-Paige.jpg",
                            PutanjaPostera = "https://resizing.flixster.com/4MrL62heb7yBgBt8zllSeqNZxg4=/206x305/v2/https://flxt.tmsimg.com/assets/p7825626_p_v10_af.jpg",
                            Reziser = " Christopher Nolan",
                            Trajanje = 93,
                            YoutubeTrailer = "https://www.youtube.com/watch?v=YoHD9XEInc0&ab_channel=MovieclipsClassicTrailers",
                            Zanr = 1
                        });
                });

            modelBuilder.Entity("Bioskop.Domen.Karta", b =>
                {
                    b.Property<int>("KartaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("ProjekcijaId")
                        .HasColumnType("int");

                    b.Property<string>("RedKolona")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KartaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("ProjekcijaId");

                    b.ToTable("Karta");
                });

            modelBuilder.Entity("Bioskop.Domen.Korisnik", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pol")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KorisnikId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("Bioskop.Domen.Projekcija", b =>
                {
                    b.Property<int>("ProjekcijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VremeKrajaProjekcije")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VremeProjekcije")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjekcijaId");

                    b.HasIndex("FilmId");

                    b.HasIndex("SalaId");

                    b.ToTable("Projekcija");
                });

            modelBuilder.Entity("Bioskop.Domen.Sala", b =>
                {
                    b.Property<int>("SalaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojKolona")
                        .HasColumnType("int");

                    b.Property<int>("BrojRedova")
                        .HasColumnType("int");

                    b.Property<string>("NazivSale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalaId");

                    b.ToTable("Sala");

                    b.HasData(
                        new
                        {
                            SalaId = 1,
                            BrojKolona = 0,
                            BrojRedova = 0,
                            NazivSale = "Sala Marilyn Monroe"
                        });
                });

            modelBuilder.Entity("Bioskop.Domen.Karta", b =>
                {
                    b.HasOne("Bioskop.Domen.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bioskop.Domen.Projekcija", "Projekcija")
                        .WithMany()
                        .HasForeignKey("ProjekcijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bioskop.Domen.Projekcija", b =>
                {
                    b.HasOne("Bioskop.Domen.Film", "Film")
                        .WithMany("Sale")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bioskop.Domen.Sala", "Sala")
                        .WithMany("Filmovi")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bioskop.Domen.Sala", b =>
                {
                    b.OwnsMany("Bioskop.Domen.Sediste", "SedistaUSali", b1 =>
                        {
                            b1.Property<int>("SalaId")
                                .HasColumnType("int");

                            b1.Property<int>("SedisteId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Kolona")
                                .HasColumnType("int");

                            b1.Property<string>("Red")
                                .IsRequired()
                                .HasColumnType("nvarchar(1)");

                            b1.Property<bool>("SlobodnoSediste")
                                .HasColumnType("bit");

                            b1.HasKey("SalaId", "SedisteId");

                            b1.ToTable("Sediste");

                            b1.WithOwner("Sala")
                                .HasForeignKey("SalaId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
