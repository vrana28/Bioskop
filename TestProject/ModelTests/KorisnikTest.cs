using System;
using System.Collections.Generic;
using System.Text;
using Bioskop.Domen;
using EShop.Model.Exceptions;
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
        public void Test_KorisnikImeException() {
            Assert.ThrowsException<NullReferenceException>(() => korisnik.Ime = "");
            Assert.ThrowsException<NullReferenceException>(() => korisnik.Ime = null);
        }

        [TestMethod]
        public void Test_KorisnikPrezimeException()
        {
            Assert.ThrowsException<NullReferenceException>(() => korisnik.Prezime = "");
            Assert.ThrowsException<NullReferenceException>(() => korisnik.Prezime = null);
        }
        [TestMethod]
        public void Test_KorisnikUsernameException()
        {
            Assert.ThrowsException<NullReferenceException>(() => korisnik.Username = "");
            Assert.ThrowsException<NullReferenceException>(() => korisnik.Username = null);
        }


        [TestMethod]
        [DataRow("mare@gmail")]
        [DataRow("mare@gmail.c")]
        [DataRow("mare")]
        public void Test_KorisnikEmailExcepion(string email)
        {
            Assert.ThrowsException<EmailException>(() => korisnik.Email = email);
        }

        [TestMethod]
        [DataRow("Mia3@")]
        [DataRow("Mia32121")]
        [DataRow("33313qaas@")]
        [DataRow("MQQQ@@")]
        public void Test_KorisnikPasswordExcepion(string password)
        {
            Assert.ThrowsException<PasswordException>(() => korisnik.Password = password);
        }


    }
}
