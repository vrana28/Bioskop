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
    [Migration("20210214134136_Seed")]
    partial class Seed
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reziser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Trajanje")
                        .HasColumnType("int");

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
                            Reziser = " Andrew Adamson",
                            Trajanje = 93,
                            Zanr = 0
                        },
                        new
                        {
                            FilmId = 2,
                            Godina = 2008,
                            Naziv = "Kung Fu Panda",
                            Reziser = " Mark Osborne",
                            Trajanje = 92,
                            Zanr = 2
                        },
                        new
                        {
                            FilmId = 3,
                            Godina = 2010,
                            Naziv = "Inception",
                            Reziser = " Christopher Nolan",
                            Trajanje = 93,
                            Zanr = 1
                        });
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
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<DateTime>("VremeProjekcije")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjekcijaId", "FilmId", "SalaId");

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

                    b.Property<string>("NazivSale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Slobodna")
                        .HasColumnType("bit");

                    b.HasKey("SalaId");

                    b.ToTable("Sala");
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

                            b1.Property<int>("Red")
                                .HasColumnType("int");

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
