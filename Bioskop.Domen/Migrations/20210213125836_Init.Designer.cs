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
    [Migration("20210213125836_Init")]
    partial class Init
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

                    b.Property<DateTime>("Vreme")
                        .HasColumnType("datetime2");

                    b.Property<int>("Zanr")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("Bioskop.Domen.Karta", b =>
                {
                    b.Property<int>("KartaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjekcijaId")
                        .HasColumnType("int");

                    b.Property<int?>("SedisteId")
                        .HasColumnType("int");

                    b.HasKey("KartaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("ProjekcijaId");

                    b.HasIndex("SedisteId");

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

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<int?>("SalaId")
                        .HasColumnType("int");

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

                    b.Property<string>("NazivSale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Slobodna")
                        .HasColumnType("bit");

                    b.HasKey("SalaId");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("Bioskop.Domen.Sediste", b =>
                {
                    b.Property<int>("SedisteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kolona")
                        .HasColumnType("int");

                    b.Property<int>("Red")
                        .HasColumnType("int");

                    b.Property<int?>("SalaId")
                        .HasColumnType("int");

                    b.Property<bool>("SlobodnoSediste")
                        .HasColumnType("bit");

                    b.HasKey("SedisteId");

                    b.HasIndex("SalaId");

                    b.ToTable("Sediste");
                });

            modelBuilder.Entity("Bioskop.Domen.Karta", b =>
                {
                    b.HasOne("Bioskop.Domen.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");

                    b.HasOne("Bioskop.Domen.Projekcija", "Projekcija")
                        .WithMany()
                        .HasForeignKey("ProjekcijaId");

                    b.HasOne("Bioskop.Domen.Sediste", "Sediste")
                        .WithMany()
                        .HasForeignKey("SedisteId");
                });

            modelBuilder.Entity("Bioskop.Domen.Projekcija", b =>
                {
                    b.HasOne("Bioskop.Domen.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId");

                    b.HasOne("Bioskop.Domen.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaId");
                });

            modelBuilder.Entity("Bioskop.Domen.Sediste", b =>
                {
                    b.HasOne("Bioskop.Domen.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaId");
                });
#pragma warning restore 612, 618
        }
    }
}
