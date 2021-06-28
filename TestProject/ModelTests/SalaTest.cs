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

        [TestInitialize]
        public void Initialize() {
            sala = new Sala();
        }

        [TestMethod]
        public void Test_SalaNazivException() {
            Assert.ThrowsException<NullReferenceException>(() => sala.NazivSale = "");
            Assert.ThrowsException<NullReferenceException>(() => sala.NazivSale = null);
        }

        [TestMethod]
        public void Test_SalaKolonaException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sala.BrojKolona = 0);
        }

        [TestMethod]
        [DataRow(-15)]
        [DataRow(0)]
        public void Test_SalaKolonaParametrizovanException(int kol)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sala.BrojKolona = kol);
        }

        [TestMethod]
        [DataRow(-12)]
        [DataRow(0)]
        public void Test_SalaRedParametrizovanException(int red)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sala.BrojRedova = red);
        }

    }
}
