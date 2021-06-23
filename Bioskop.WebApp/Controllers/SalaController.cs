using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bioskop.Domen;
using Bioskop.Podaci.UnitOfWork;
using Bioskop.WebApp.Filters;
using Bioskop.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace Bioskop.WebApp.Controllers
{
    /// <summary>
    /// Represent controller for Sala (hall) controller
    /// </summary>
    [LoggedInKorisnik]
    public class SalaController : Controller
    {
        /// <value>Represent unit of work</value>
        private readonly IUnitOfWork unitOfWork;
        public SalaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Rerturns all halls
        /// </summary>
        /// <returns>List of Sala</returns>
        // GET: Sala
        public ActionResult Index()
        {
            List<Sala> sale = unitOfWork.Sala.VratiSve();
            ViewBag.IsLoggedIn = true;
           // ViewBag.Username = HttpContext.Session.GetString("username");
            return View("Index", sale);
        }

        // GET: Sala/Details/5
        public ActionResult Details(int id)
        {
            Sala model = unitOfWork.Sala.NadjiPoId(id);
            return View(model);
        }


        // GET: Sala/Create
        public ActionResult Create()
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }


        /// <summary>
        /// Creating sala (hall)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Redirect based on entered data</returns>
        /// <exception cref="Exception">Number of rows and colums cant be negative.</exception>
        // POST: Sala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSalaViewModel model)
        {
            try
            {
                if (model == null) throw new NullReferenceException();
                if (model.Sala.BrojKolona <= 0 || model.Sala.BrojRedova <= 0) throw new Exception();
                unitOfWork.Sala.Dodaj(model.Sala);
           //     unitOfWork.Sala.DodajSvaSedista(model.Sala);

                unitOfWork.Commit();
                return RedirectToAction("Index", "Sala");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Broj kolona/redova ne moze biti negativan.");
                return RedirectToAction("Create");
            }
        }

        // GET: Sala/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // POST: Sala/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Deleting sala (hall)
        /// </summary>
        /// <param name="id">Sala id as int</param>
        /// <returns>Redirecting to index page</returns>
        public ActionResult Delete(int id)
        {
            Sala model = unitOfWork.Sala.NadjiPoId(id);
            ViewBag.IsLoggedIn = true;
           // ViewBag.Username = HttpContext.Session.GetString("username");
            List<Projekcija> projekcije = new List<Projekcija>();
            projekcije = unitOfWork.Projekcija.VratiSve();
            unitOfWork.Projekcija.izbrisiSvePSala(id, projekcije);

            unitOfWork.Sala.Delete(model);
            unitOfWork.Commit();
            return RedirectToAction("Index");
        }
        // POST: Sala/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}