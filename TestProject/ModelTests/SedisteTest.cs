using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Bioskop.Domen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.ModelTests
{
    [TestClass]
    public class SedisteTest
    {
        private Sediste sediste;

        public void Initialize()
        {
            sediste = new Sediste();
        }

        [TestMethod]
        public void Test_SedisteNull()
        {
            sediste= null;
            Assert.ThrowsException<NullReferenceException>(() => sediste.SlobodnoSediste);
        }

        [TestMethod]
        public void Test_SedisteNotNull() {
            sediste = new Sediste();
            Assert.IsNotNull(sediste);
        }

        [TestMethod]
        public void Test_SedisteRed() {
            sediste = new Sediste
            {
                SedisteId = 1,
                Red = 'A',
                Kolona = 3,
                Sala = new Sala(),
                SalaId = 1,
                SlobodnoSediste = true,
                Projekcija = new Projekcija(),
                ProjekcijaId = 1,
            };
            Assert.IsNotNull(sediste);
            Assert.AreEqual(sediste.Red.ToString().Length, 1);
        }

        [TestMethod]
        public void Test_SedisteKolona()
        {
            sediste = new Sediste
            {
                SedisteId = 1,
                Red = 'A',
                Kolona = 3,
                Sala = new Sala(),
                SalaId = 1,
                SlobodnoSediste = true,
                Projekcija = new Projekcija(),
                ProjekcijaId = 1,
            };
            Assert.IsNotNull(sediste);
            Assert.IsTrue(sediste.Kolona > 0);
        }

        [TestMethod]
        public void Test_SedisteSalaNull()
        {
            sediste = new Sediste
            {
                SedisteId = 1,
                Red = 'A',
                Kolona = 3,
                SlobodnoSediste = true,
                Projekcija = new Projekcija(),
                ProjekcijaId = 1,
            };
            Assert.IsNotNull(sediste);
            Assert.ThrowsException<NullReferenceException>(() => sediste.Sala.NazivSale);
        }

        [TestMethod]
        public void Test_SedisteProjekcijaNull()
        {
            sediste = new Sediste
            {
                SedisteId = 1,
                Red = 'A',
                Kolona = 3,
                SlobodnoSediste = true,
                Sala = new Sala(),
                SalaId = 1,
            };
            Assert.IsNotNull(sediste);
            Assert.ThrowsException<NullReferenceException>(() => sediste.Projekcija.VremeProjekcije);
        }
    }
}
