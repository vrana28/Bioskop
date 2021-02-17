using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bioskop.Domen;
using Bioskop.Podaci.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bioskop.WebApp.Controllers
{
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

            return View(unitOfWork.Sala.VratiSve());
        }

        // GET: Sala/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sala/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromRoute]Sala sala)
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
            return View();
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