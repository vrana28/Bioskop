using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bioskop.Domen;
using Bioskop.Podaci.UnitOfWork;
using Bioskop.WebApp.Filters;
using Bioskop.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Components;
using Microsoft.Web.Helpers;

namespace Bioskop.WebApp.Controllers
{
    /// <summary>
    /// Controller for Film class
    /// </summary>
    public class FilmController : Controller
    {
        /// <values>Represent unitOfWork attribute</values>
        private readonly IUnitOfWork unitOfWork;
        
        public FilmController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns list of Films after he check users session.
        /// </summary>
        /// <returns> List of Films as object Film</returns>
        // GET: Film
        [NotLoggedIn]
        public ActionResult Index()
        {
            List<Film> filmovi = unitOfWork.Film.VratiSve();
            //int? userid = HttpContext.Session.GetInt32("userid");
            //if (userid != null)
            //{
            //    ViewBag.IsLoggedIn = true;
            //    ViewBag.Username = HttpContext.Session.GetString("username");
            //}
            //else
            //{
            //    return View("Index", filmovi);
            //}
            return View("Index", filmovi);
        }

        // eksplicitno naglasavanje da dolazi iz rute.. [FromRoute] 
        /// <summary>
        /// Returns model (Film) of selected id from route. 
        /// </summary>
        /// <param name="id">Int representation of films id</param>
        /// <returns>Model as Film</returns>
        [NotLoggedIn]
        public ActionResult Details([FromRoute] int id) {

            Film model = unitOfWork.Film.NadjiPoId(id);
            ViewBag.IsLoggedIn = true;
            //ViewBag.Username = HttpContext.Session.GetString("username");
            //model.PutanjaBackPostera = model.PutanjaBackPostera.Replace("//")
            return View(model);
        }

        /// <summary>
        /// Getting Hall from database, so it can be used for creating Filme
        /// </summary>
        /// <returns>Model as list of Sala (selected item)</returns>
        [LoggedInKorisnik]
        [HttpGet]
        public ActionResult Create() {
            //ViewData["Zanr"] = unitOfWork.Zanr.GetAll(); za uvodjenje dodatnih modela
            List<Sala> list = unitOfWork.Sala.VratiSve();
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            List<SelectListItem> selectList = list.Select(s => new SelectListItem { Text = s.NazivSale, Value = s.SalaId.ToString() }).ToList();
            CreateFilmViewModel model = new CreateFilmViewModel
            {
                Sale = selectList
            };

            return View(model);
        }

        // da posmatra kao podatke sa forme
        // za JSON [FromBody]
        /// <summary>
        /// Adding Films in database
        /// </summary>
        /// <param name="viewModel">Model as film who will be added int database</param>
        /// <returns>Redirect to Create page</returns>
        [LoggedInKorisnik]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateFilmViewModel viewModel)
        {
            try
            {
                if (viewModel == null) throw new NullReferenceException();
                if (viewModel.Film.Naziv == null || viewModel.Film.OpisFilma == null || viewModel.Film.PutanjaBackPostera == null
                    || viewModel.Film.PutanjaPostera == null || viewModel.Film.Trajanje == 0) throw new Exception();
                unitOfWork.Film.Dodaj(viewModel.Film);
                unitOfWork.Commit();
                return RedirectToAction("Index", "Film");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Morate uneti sva polja");
                return RedirectToAction("Create");
            }
        }

        /// <summary>
        /// Getting Sala from database
        /// </summary>
        /// <param name="request">Model as Projekcija</param>
        /// <returns>Model as ProjekcijaPartial</returns>
        [LoggedInKorisnik]
        [HttpPost]
        public ActionResult AddSala(ProjekcijaViewModel request) {
            Sala s = unitOfWork.Sala.NadjiPoId(request.SalaId);
            ProjekcijaViewModel model = new ProjekcijaViewModel
            {
                Num = request.Num,
                SalaId = request.SalaId,
                NazivSale = s.NazivSale
            };
            return PartialView("ProjekcijaPartial",model);
        }

        /// <summary>
        /// Deleting film
        /// </summary>
        /// <param name="id">Film id as int</param>
        /// <returns>Redirection to Index page</returns>
        [NotLoggedIn]          
        public ActionResult Delete([FromRoute] int id)
        {
            Film model = unitOfWork.Film.NadjiPoId(id);
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");

            List<Projekcija> projekcije = new List<Projekcija>();

            projekcije = unitOfWork.Projekcija.VratiSve();
            unitOfWork.Projekcija.izbrisiSvePFilm(id, projekcije);


            unitOfWork.Film.Delete(model);
            unitOfWork.Commit();
            return RedirectToAction("Index");
        }

    }
}