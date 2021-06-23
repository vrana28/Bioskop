using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioskop.WebApp.Controllers;
using Bioskop.Podaci.UnitOfWork;
using Moq;
using Bioskop.Podaci.Implementacija;
using Microsoft.AspNetCore.Mvc;
using Bioskop.Domen;
using System.Linq;

namespace TestProject.SOTests
{
    [TestClass]
    public class FilmControllerTest
    {
        private Mock<IUnitOfWork> uow;
        private FilmController controller;

        [TestInitialize]
        public void Initialize() {
            uow = MoqClass.Mocks.GetMockUnitOfWork();
            controller = new FilmController(uow.Object);
        }

        [TestMethod]
        public void Test_FilmGetAllMethod() {
            controller = new FilmController(uow.Object);
            var expected = controller.Index() as ViewResult;
            var exp = (List<Film>)expected.ViewData.Model;
            var actual = uow.Object.Film.VratiSve().ToList();

            var ocekivani = exp[1];
            var stvarni = actual[1];

            Assert.IsNotNull(exp);
            Assert.AreEqual(ocekivani.Naziv, stvarni.Naziv);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(exp[i].FilmId, actual[i].FilmId);
            }
        }

        [TestMethod]
        public void Test_FilmFindMethod() {

            controller = new FilmController(uow.Object);
            var expected = controller.Details(1) as ViewResult;
            var exp = (Film)expected.ViewData.Model;
            var actual = uow.Object.Film.NadjiPoId(1);

            Assert.IsTrue(exp != null);
            Assert.AreEqual(exp.FilmId, actual.FilmId);
            Assert.AreEqual(exp.Naziv, actual.Naziv);
            Assert.AreEqual(exp.OpisFilma, actual.OpisFilma);
            Assert.AreEqual(exp.Reziser, actual.Reziser);

        }

        [TestMethod]
        public void Test_FilmAddMethod() {

            controller = new FilmController(uow.Object);
            var expected = controller.Create(null) as ViewResult;
            Assert.IsNull(expected);
        }

    }
}
