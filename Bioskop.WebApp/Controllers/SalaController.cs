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
    [LoggedInKorisnik]
    public class SalaController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public SalaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: Sala
        public ActionResult Index()
        {
            List<Sala> sale = unitOfWork.Sala.VratiSve();
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View("Index", sale);
        }



        // GET: Sala/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: Sala/Create
        public ActionResult Create()
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }



        // POST: Sala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSalaViewModel model)
        {
            try
            {
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

        // GET: Sala/Delete/5
      /*  public ActionResult Delete(int id)
        {
            Sala model = unitOfWork.Sala.NadjiPoId(id);
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            List<Projekcija> projekcije = new List<Projekcija>();
            projekcije = unitOfWork.Projekcija.VratiSve();
            foreach (Projekcija p in projekcije)
            {
                if (p.SalaId == id)
                {
                    unitOfWork.Projekcija.Delete(p);
                }
            }

            unitOfWork.Sala.Delete(model);
            unitOfWork.Commit();
            return RedirectToAction("Index");
        }*/
        public ActionResult Delete(int id)
        {
            Sala model = unitOfWork.Sala.NadjiPoId(id);
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
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