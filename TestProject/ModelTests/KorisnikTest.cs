using System;
using System.Collections.Generic;
using System.Text;
using Bioskop.Domen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.ModelTests
{
    [TestClass]
    public class KorisnikTest
    {
        private Korisnik korisnik;

        [TestInitialize]
        public void Initialize() {
            korisnik = new Korisnik();
        }

        [TestMethod]
        public void Test_KorisnikNull() {
            korisnik = null;
            Assert.ThrowsException<NullReferenceException>(() => korisnik.Ime);
        }

        [TestMethod]
        public void Test_KorisnikType() {
            korisnik = new Korisnik
            {
                KorisnikId = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Pol = Pol.Muški,
                Username = "peki",
                Email = "pera@gmail.com",
                Password = "pera1234",
            };

            Assert.AreEqual(korisnik.Ime, "Pera");
        }

        [TestMethod]
        public void Test_PrezimeString() {
            korisnik = new Korisnik
            {
                KorisnikId = 1,
                Ime = "Pera",
                Prezime = "p",
                Pol = Pol.Muški,
                Username = "peki",
                Email = "pera@gmail.com",
                Password = "pera1234",
            };
            int num = korisnik.Prezime.Length;
            Assert.AreEqual(num, korisnik.Prezime.Length);
        }

        [TestMethod]
        public void Test_UsernameContains() {
            korisnik = new Korisnik
            {
                KorisnikId = 1,
                Ime = "Pera",
                Prezime = "p",
                Pol = Pol.Muški,
                Username = "peki",
                Email = "pera@gmail.com",
                Password = "pera1234",
            };
            Assert.IsNotNull(korisnik);
            Assert.IsTrue(korisnik.Email.Contains("@"));
        }

        [TestMethod]
        public void Test_KorisnikId() {
            korisnik = new Korisnik
            {
                KorisnikId = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Pol = Pol.Muški,
                Username = "peki",
                Email = "pera@gmail.com",
                Password = "pera1234",
            };
            Assert.IsNotNull(korisnik);
            Assert.IsTrue(korisnik.KorisnikId > 0);
        }

        [TestMethod]
        public void Test_KorisnikPassword() {
            korisnik = new Korisnik
            {
                KorisnikId = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Pol = Pol.Muški,
                Username = "peki",
                Email = "pera@gmail.com",
                Password = "pera1234",
            };
            Assert.ThrowsException<FormatException>(() => int.Parse(korisnik.Password));
        }

        [TestMethod]
        public void Test_KorisnikEmail() {
            korisnik = new Korisnik
            {
                KorisnikId = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Pol = Pol.Muški,
                Username = "peki",
                Email = "pera@gmail.com",
                Password = "pera1234",
            };
            Assert.IsNotNull(korisnik);
            Assert.IsTrue(korisnik.Email.Contains("."));
        }

    }
}
