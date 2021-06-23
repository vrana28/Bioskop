using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioskop.WebApp.Controllers;
using Moq;
using Bioskop.Domen;
using System.Linq;
using Bioskop.Podaci.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.SOTests
{
    [TestClass]
    public class SalaControllerTest
    {
        private Mock<IUnitOfWork> uow;
        private SalaController controller;

        [TestInitialize]
        public void Initialize()
        {
            uow = MoqClass.Mocks.GetMockUnitOfWork();
            controller = new SalaController(uow.Object);
        }

        [TestMethod]
        public void Test_SalaGetAllMethod()
        {
            controller = new SalaController(uow.Object);
            var expected = controller.Index() as ViewResult;
            var exp = (List<Sala>)expected.ViewData.Model;
            var actual = uow.Object.Sala.VratiSve().ToList();

            var ocekivani = exp[1];
            var stvarni = actual[1];

            Assert.IsNotNull(exp);
            Assert.AreEqual(ocekivani.NazivSale, stvarni.NazivSale);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(exp[i].SalaId, actual[i].SalaId);
            }
        }

        [TestMethod]
        public void Test_SalaFindMethod()
        {

            controller = new SalaController(uow.Object);
            var expected = controller.Details(1) as ViewResult;
            var exp = (Sala)expected.ViewData.Model;
            var actual = uow.Object.Sala.NadjiPoId(1);

            Assert.IsTrue(exp != null);
            Assert.AreEqual(exp.SalaId, actual.SalaId);
            Assert.AreEqual(exp.NazivSale, actual.NazivSale);
            Assert.AreEqual(exp.BrojKolona, actual.BrojKolona);
            Assert.AreEqual(exp.BrojRedova, actual.BrojRedova);

        }

    }
}
