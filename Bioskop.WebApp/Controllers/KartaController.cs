using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bioskop.Domen;
using Bioskop.Podaci.UnitOfWork;
using Bioskop.Podaci.UnitOfWork.Korisnici;
using Bioskop.WebApp.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bioskop.WebApp.Controllers
{
    [LoggedInKorisnik]
    public class KartaController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IKorisniciUnitOfWork unitOfWorkKorisnik;
        public KartaController(IUnitOfWork unitOfWork, IKorisniciUnitOfWork unitOfWorkKorisnik)
        {
            this.unitOfWork = unitOfWork;
            this.unitOfWorkKorisnik = unitOfWorkKorisnik;
        }
        // GET: Karta
        public ActionResult Index()
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View("Index");
        }

        // GET: Karta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Karta/Create
        public ActionResult Create(int id)
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            Projekcija p = unitOfWork.Projekcija.NadjiPoId(id);
            Sala s = unitOfWork.Sala.NadjiPoId(p.SalaId);
            Film f = unitOfWork.Film.NadjiPoId(p.FilmId);
            //s.SedistaUSali = unitOfWork.Sediste.VratiSvePoId(s.SalaId);
            p.Sala = s;
            p.Film = f;
            Karta k = new Karta
            {
                Projekcija = p,
                Korisnik = unitOfWorkKorisnik.Korisnici.NadjiPoId((int)HttpContext.Session.GetInt32("userid")),
            };

            return View(k);
        }

        // POST: Karta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Karta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Karta/Edit/5
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

        // GET: Karta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Karta/Delete/5
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