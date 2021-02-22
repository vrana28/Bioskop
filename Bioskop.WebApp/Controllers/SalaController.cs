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
                unitOfWork.Sala.Dodaj(model.Sala);
                int bk = model.Sala.BrojKolona + 1;
                int br = model.Sala.BrojRedova + 1;
                for (int i = 1; i < bk; i++)
                {
                    for (int j = 1; j < br; j++)
                    {
                        char r = (char)(j + 'a' - 1);
                        unitOfWork.Sediste.Dodaj(new Sediste { Kolona = i, Red = r, Sala = model.Sala, SalaId = model.Sala.SalaId});
                    }

                }
                unitOfWork.Commit();
                return RedirectToAction("Index", "Sala");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
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
        public ActionResult Delete(int id)
        {
            Sala model = unitOfWork.Sala.NadjiPoId(id);
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
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