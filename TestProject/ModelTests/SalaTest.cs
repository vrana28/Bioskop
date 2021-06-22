using System;
using System.Collections.Generic;
using System.Text;
using Bioskop.Domen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.ModelTests
{
    [TestClass]
    public class SalaTest
    {

        private Sala sala;

        public void Initialize() {
            sala = new Sala();
        }

        [TestMethod]
        public void Test_SalaNull() {
            sala = null;
            Assert.ThrowsException<NullReferenceException>(() => sala.NazivSale);
        }

        [TestMethod]
        public void Test_SalaNotNull() {
            sala = new Sala();
            Assert.IsNotNull(sala);
        }

        [TestMethod]
        public void Test_SalaNazivString() {

            sala = new Sala
            {
                SalaId = 1,
                NazivSale = "Nova Sala",
                SedistaUSali = new List<Sediste>(),
                Filmovi = new List<Projekcija>(),
                BrojRedova = 12, 
                BrojKolona = 11,
            };

            Assert.IsNotNull(sala);
            Assert.AreEqual("Nova Sala", sala.NazivSale);
            
        }

        [TestMethod]
        public void Test_SalaBrojKolona() {
            sala = new Sala
            {
                SalaId = 1,
                NazivSale = "Nova Sala",
                SedistaUSali = new List<Sediste>(),
                Filmovi = new List<Projekcija>(),
                BrojRedova = 12,
                BrojKolona = 11,
            };
            Assert.IsNotNull(sala);
            Assert.IsTrue(sala.BrojKolona > 0);

        }

        [TestMethod]
        public void Test_SalaBrojRedova()
        {
            sala = new Sala
            {
                SalaId = 1,
                NazivSale = "Nova Sala",
                SedistaUSali = new List<Sediste>(),
                Filmovi = new List<Projekcija>(),
                BrojRedova = 12,
                BrojKolona = 11,
            };
            Assert.IsNotNull(sala);
            Assert.IsTrue(sala.BrojRedova > 0);

        }

        [TestMethod]
        public void Test_SalaSedista()
        {
            sala = new Sala
            {
                SalaId = 1,
                NazivSale = "Nova Sala",
                SedistaUSali = new List<Sediste>(),
                Filmovi = new List<Projekcija>(),
                BrojRedova = 12,
                BrojKolona = 11,
            };
            Assert.IsNotNull(sala);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sala.SedistaUSali[1].Red);

        }

        [TestMethod]
        public void Test_SalaProjekcije()
        {
            sala = new Sala
            {
                SalaId = 1,
                NazivSale = "Nova Sala",
                SedistaUSali = new List<Sediste>(),
                Filmovi = new List<Projekcija>(),
                BrojRedova = 12,
                BrojKolona = 11,
            };
            Assert.IsNotNull(sala);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sala.Filmovi[1].VremeProjekcije);

        }

    }
}
