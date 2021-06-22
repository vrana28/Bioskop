using Bioskop.Domen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.ModelTests
{
    [TestClass]
    public class KartaTest
    {
        private Karta karta;

        public void Initialize() {
            karta = new Karta();
        }

        [TestMethod]
        public void Test_KartaNull() {
            karta = null;
            Assert.ThrowsException<NullReferenceException>(() => karta.RedKolona);
        }

        [TestMethod]
        public void Test_KartaNotNull() {
            karta = new Karta();
            Assert.IsNotNull(karta);
        }

        [TestMethod]
        public void Test_KartaKorisnik() {
            karta = new Karta
            {
                KartaId = 1,
                Korisnik = new Korisnik(),
                KorisnikId = 2,
                Projekcija = new Projekcija(),
                ProjekcijaId = 1,
                 RedKolona = "A3"
            };
            Assert.IsNotNull(karta.Korisnik);
        }

        [TestMethod]
        public void Test_KartaRedKolona() {
            karta = new Karta
            {
                KartaId = 1,
                Korisnik = new Korisnik(),
                KorisnikId = 2,
                Projekcija = new Projekcija(),
                ProjekcijaId = 1,
                RedKolona = "A3"
            };
            int num = karta.RedKolona.Length;
            Assert.IsNotNull(karta);
            Assert.AreEqual(num, 2);
        }

        [TestMethod]
        public void Test_KartaProjekcijaIdNotNegative() {
            
            karta = new Karta
            {
                KartaId = 1,
                Korisnik = new Korisnik(),
                KorisnikId = 2,
                Projekcija = new Projekcija(),
                ProjekcijaId = 1,
                RedKolona = "A3"
            };
            Assert.IsNotNull(karta);
            Assert.IsTrue(karta.ProjekcijaId > 0);
        }

        [TestMethod]
        public void Test_KartaKorisnikIdNotNegative() {

            karta = new Karta
            {
                KartaId = 1,
                Korisnik = new Korisnik(),
                KorisnikId = 2,
                Projekcija = new Projekcija(),
                ProjekcijaId = 1,
                RedKolona = "A3"
            };

            Assert.IsNotNull(karta);
            Assert.IsTrue(karta.KorisnikId > 0);
        }

        [TestMethod]
        public void Test_KartaRedKolonaValid() {

            karta = new Karta
            {
                KartaId = 1,
                Korisnik = new Korisnik(),
                KorisnikId = 2,
                Projekcija = new Projekcija(),
                ProjekcijaId = 1,
                RedKolona = "A3"
            };

            Assert.ThrowsException<FormatException>(() => int.Parse(karta.RedKolona));

        }

    }
}
