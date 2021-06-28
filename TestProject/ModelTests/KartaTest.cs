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
        public void Test_KartaRedKolonaException()
        {
            Assert.ThrowsException<NullReferenceException>(() => karta.RedKolona = "");
            Assert.ThrowsException<NullReferenceException>(() => karta.RedKolona = null);
        }

        

    }
}
