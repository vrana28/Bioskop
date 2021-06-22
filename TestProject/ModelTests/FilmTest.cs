using System;
using System.Collections.Generic;
using System.Text;
using Bioskop.Domen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.ModelTests
{
    [TestClass]
    public class FilmTest
    {
        private Film film;

        [TestInitialize]
        public void Initialize() {
            film = new Film();
        }

        [TestMethod]
        public void Test_FilmNull() {
            film = null;
            Assert.ThrowsException<NullReferenceException>(() => film.PutanjaBackPostera);
        }

        [TestMethod]
        public void Test_FilmNazivReziser() {
            film = new Film
            {Naziv = "Nar",
            Reziser = "Marko",
            Zanr = Zanr.Akcija,
            Trajanje = 123,
            Godina = 2020,
            };
            Assert.IsNotNull(film);
            Assert.AreEqual("Nar", film.Naziv);
            Assert.AreEqual("Marko", film.Reziser);
        }

        [TestMethod]
        public void Test_FilmNazivString() {
            film = new Film
            {
                Naziv = "N",
                Reziser = "Marko",
                Zanr = Zanr.Akcija,
                Trajanje = 123,
                Godina = 2020,
            };
            int num = film.Naziv.Length;
            Assert.IsNotNull(film);
            Assert.AreEqual(1,num);
        }

        [TestMethod]
        public void Test_FilmGodina() {
            film = new Film
            {
                Naziv = "N",
                Reziser = "Marko",
                Zanr = Zanr.Akcija,
                Trajanje = 123,
                Godina = 2020,
            };
            int num = film.Godina.ToString().Length;
            Assert.IsNotNull(film);
            Assert.AreEqual(4, num);
        }

        [TestMethod]
        public void Test_FilmOpis() {
            film = new Film
            {
                Naziv = "N",
                Reziser = "Marko",
                Zanr = Zanr.Akcija,
                Trajanje = 123,
                Godina = 2020,
                OpisFilma = "Ovo je opis."
            };

            Assert.IsNotNull(film);
            Assert.IsTrue(film.OpisFilma.Length < 20);
        }

        [TestMethod]
        public void Test_FilmTrailer() {
            film = new Film
            {
                Naziv = "Nar",
                Reziser = "Marko",
                Zanr = Zanr.Akcija,
                Trajanje = 123,
                Godina = 2020,
                OpisFilma = "Ovo je opis.",
                YoutubeTrailer = "https://www.youtube.com/watch?v=2Ld0IfAfqPc"
            };

            Assert.IsNotNull(film);
            Assert.IsTrue(film.YoutubeTrailer.Contains("youtube"));
        }

        [TestMethod]
        public void Test_FilmProjekcija() {
            film = new Film
            {
                Naziv = "Nar",
                Reziser = "Marko",
                Zanr = Zanr.Akcija,
                Trajanje = 123,
                Godina = 2020,
                OpisFilma = "Ovo je opis.",
                YoutubeTrailer = "https://www.youtube.com/watch?v=2Ld0IfAfqPc"
            };
            Assert.ThrowsException<NullReferenceException>(() => film.Sale[1]);
        }

    }
}
