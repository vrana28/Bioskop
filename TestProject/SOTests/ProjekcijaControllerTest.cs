using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioskop.WebApp.Controllers;
using Bioskop.Podaci.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Bioskop.Domen;
using System.Linq;
using Moq;

namespace TestProject.SOTests
{
    [TestClass]
    public class ProjekcijaControllerTest
    {

        private Mock<IUnitOfWork> uow;
        private ProjekcijaController controller;

        [TestInitialize]
        public void Initialize()
        {
            uow = MoqClass.Mocks.GetMockUnitOfWork();
            controller = new ProjekcijaController(uow.Object);
        }

        [TestMethod]
        public void Test_ProjekcijaGetAllMethod()
        {
            controller = new ProjekcijaController(uow.Object);
            var expected = controller.Index() as ViewResult;
            var exp = (List<Projekcija>)expected.ViewData.Model;
            var actual = uow.Object.Projekcija.VratiSve().OrderBy(x => x.VremeProjekcije).ToList();

            var ocekivani = exp.First();
            var stvarni = actual.First();

            Assert.IsNotNull(exp);
            Assert.AreEqual(ocekivani.ProjekcijaId, stvarni.ProjekcijaId);
        }

        [TestMethod]
        public void Test_ProjekcijaFindMethod()
        {

            controller = new ProjekcijaController(uow.Object);
            var expected = controller.Details(1) as ViewResult;
            var exp = (List<Projekcija>)expected.ViewData.Model;
            var actual = uow.Object.Projekcija.VratiSveSaId(1);

            Assert.IsTrue(exp != null);
            Assert.AreEqual(exp[0].ProjekcijaId, actual[0].ProjekcijaId);
            Assert.AreEqual(exp[0].VremeProjekcije, actual[0].VremeProjekcije);
            Assert.AreEqual(exp[0].VremeKrajaProjekcije, actual[0].VremeKrajaProjekcije);
        }

    }
}
