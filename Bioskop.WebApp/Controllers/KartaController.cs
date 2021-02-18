using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bioskop.WebApp.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bioskop.WebApp.Controllers
{
    [LoggedInKorisnik]
    public class KartaController : Controller
    {
        // GET: Karta
        public ActionResult Index()
        {
            return View("Index");
        }

        // GET: Karta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Karta/Create
        public ActionResult Create()
        {
            return View();
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