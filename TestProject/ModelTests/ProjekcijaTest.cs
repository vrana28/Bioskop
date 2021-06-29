using System;
using System.Collections.Generic;
using System.Text;
using Bioskop.Domen;
using EShop.Model.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.ModelTests
{
    [TestClass]
    public class ProjekcijaTest
    {

        private Projekcija projekcija;

        [TestInitialize]
        public void Initialize() {
            projekcija = new Projekcija();
        }

        [TestMethod]
        public void Test_ProjekcijaPocetakProjekcijeException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => projekcija.VremeKrajaProjekcije = DateTime.Now);
        }

        [TestMethod]
        public void Test_ProjekcijaKrajProjekcijeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => projekcija.VremeKrajaProjekcije = DateTime.Now);
        }

        [TestMethod]
        [DataRow("01/03/2008 07:00:00")]

        public void Test_ProjekcijaPocetakException(string pocetak) {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => projekcija.VremeProjekcije = DateTime.Parse(pocetak));
        }

        [TestMethod]
        [DataRow("01/03/2008 07:00:00")]
        public void Test_ProjekcijaKrajException(string kraj)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => projekcija.VremeKrajaProjekcije = DateTime.Parse(kraj));
        }

        [TestMethod]
        public void Test_ProjekcijaCenaException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => projekcija.Cena = -1.5);
        }




    }
}
