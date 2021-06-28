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

        [TestInitialize]
        public void Initialize()
        {
            sediste = new Sediste();
        }

        [TestMethod]
        public void Test_SedisteRedException()
        {
            Assert.ThrowsException<NullReferenceException>(() => sediste.Red =' ');
        }

        [TestMethod]
        public void Test_SedisteKolonaException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sediste.Kolona = 0);
        }

        [TestMethod]
        [DataRow(-15)]
        [DataRow(0)]
        public void Test_SedisteRedException(int kolona)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sediste.Kolona = kolona);
        }



    }
}
