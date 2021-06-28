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
        public void Test_FilmNameException()
        {
            Assert.ThrowsException<NullReferenceException>(() => film.Naziv = "");
            Assert.ThrowsException<NullReferenceException>(() => film.Naziv = null);
        }

        [TestMethod]
        public void Test_FilmReziserException()
        {
            Assert.ThrowsException<NullReferenceException>(() => film.Reziser = "");
            Assert.ThrowsException<NullReferenceException>(() => film.Reziser = null);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-5)]
        [DataRow(1850)]
        public void Test_FilmGodinaException(int godina) {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => film.Godina = godina);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-5)]
        public void Test_FilmTrajanjeException(int trajanje) {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => film.Trajanje = trajanje);
        }

        [TestMethod]
        [DataRow(null)]
        public void Test_FilmZanrException(Zanr p) {
            Assert.ThrowsException<NullReferenceException>(() => film.Zanr = p);
        }

    }
}
