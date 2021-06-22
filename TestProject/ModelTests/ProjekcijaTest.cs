using System;
using System.Collections.Generic;
using System.Text;
using Bioskop.Domen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.ModelTests
{
    [TestClass]
    public class ProjekcijaTest
    {

        private Projekcija projekcija;

        public void Initialize() {
            projekcija = new Projekcija();
        }

        [TestMethod]
        public void Test_ProjekcijaNull() {
            projekcija = null;
            Assert.ThrowsException<NullReferenceException>(() => projekcija.VremeProjekcije);
        }

        [TestMethod]
        public void Test_ProjekcijaNotNull() {
            projekcija = new Projekcija();
            Assert.IsNotNull(projekcija);
        }

        [TestMethod]
        public void Test_ProjekcijaId() {

            projekcija = new Projekcija {
                ProjekcijaId = 1,
                Sala = new Sala(),
                SalaId = 1,
                Film = new Film(),
                FilmId = 1,
                VremeProjekcije = new DateTime(2021,05,12,8,30,0),
                VremeKrajaProjekcije = new DateTime(2021, 05, 12, 9, 30, 0),
                Cena = 200
            };

            Assert.IsTrue(projekcija.ProjekcijaId > 0);
        }

        [TestMethod]
        public void Test_ProjekcijaSalaNull() {

            projekcija = new Projekcija
            {
                ProjekcijaId = 1,               
                Film = new Film(),
                FilmId = 1,
                VremeProjekcije = new DateTime(2021, 05, 12, 8, 30, 0),
                VremeKrajaProjekcije = new DateTime(2021, 05, 12, 9, 30, 0),
                Cena = 200
            };

            Assert.IsNotNull(projekcija);
            Assert.ThrowsException<NullReferenceException>(() => projekcija.Sala.NazivSale);

        }

        [TestMethod]
        public void Test_VremeProjekcije() {

            projekcija = new Projekcija
            {
                ProjekcijaId = 1,
                Sala = new Sala(),
                SalaId = 1,
                Film = new Film(),
                FilmId = 1,
                VremeProjekcije = new DateTime(2021, 05, 12, 8, 30, 0),
                VremeKrajaProjekcije = new DateTime(2021, 05, 12, 9, 30, 0),
                Cena = 200
            };

            Assert.IsNotNull(projekcija);
            Assert.IsTrue(projekcija.VremeKrajaProjekcije > projekcija.VremeProjekcije);
        }
        
        [TestMethod]
        public void Test_ProjekcijaVremeNotEqual ()
        {
            projekcija = new Projekcija
            {
                ProjekcijaId = 1,
                Sala = new Sala(),
                SalaId = 1,
                Film = new Film(),
                FilmId = 1,
                VremeProjekcije = new DateTime(2021, 05, 12, 8, 30, 0),
                VremeKrajaProjekcije = new DateTime(2021, 05, 12, 9, 30, 0),
                Cena = 200.5
            };
            Assert.IsNotNull(projekcija);
            Assert.AreNotEqual(projekcija.VremeProjekcije, projekcija.VremeKrajaProjekcije);
        }


    }
}
