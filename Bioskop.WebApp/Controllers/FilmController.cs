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
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Bioskop.WebApp.Controllers
{
    [LoggedInKorisnik] // moze da se stavi na njivou kontrolera
    public class FilmController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public FilmController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Film
        [NotLoggedIn]
        public ActionResult Index()
        {
            List<Film> filmovi = unitOfWork.Film.VratiSve();
            int? userid = HttpContext.Session.GetInt32("userid");
            if (userid != null)
            {
                ViewBag.IsLoggedIn = true;
                ViewBag.Username = HttpContext.Session.GetString("username");
                //byte[] userBy = HttpContext.Session.Get("user"); // user je key
                //Korisnik k = JsonSerializer.Deserialize<Korisnik>(userBy); nece 22:43
                // za slucaj korpe je pozeljno koristiti serijalizaciju/deserijalizaciju objekta

            }
            else
            {
                return RedirectToAction("Login", "Korisnik");
            }
            return View("Index", filmovi);
        }

        // eksplicitno naglasavanje da dolazi iz rute.. [FromRoute] 
        [NotLoggedIn]
        public ActionResult Details([FromRoute] int id) {

            Film model = unitOfWork.Film.NadjiPoId(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create() {
            //ViewData["Zanr"] = unitOfWork.Zanr.GetAll(); za uvodjenje dodatnih modela
            List<Sala> list = unitOfWork.Sala.VratiSve();
            List<SelectListItem> selectList = list.Select(s => new SelectListItem { Text = s.NazivSale, Value = s.SalaId.ToString() }).ToList();
            CreateFilmViewModel model = new CreateFilmViewModel
            {
                Sale = selectList
            };

            return View(model);
        }

        // da posmatra kao podatke sa forme
        // za JSON [FromBody
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateFilmViewModel viewModel)
        {
            try
            {
                unitOfWork.Film.Dodaj(viewModel.Film);
                unitOfWork.Commit();
                return RedirectToAction("Index", "Film");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Create");
            }


            //if (!ModelState.IsValid) {
            //    return View("Create");
            //}


            //bool exist = unitOfWork.Film.Search(f => f.Naziv == film.Naziv).Any();

            //if (exist)
            //{
            //    ModelState.AddModelError("FilmName", "Film sa ovim nazivom vec postoji");
            //    return View("Create");
            //}
            //unitOfWork.Film.Dodaj(film);
            //unitOfWork.Commit();
            //return Index();
        }


        [HttpPost]
        public ActionResult AddSala(ProjekcijaViewModel request) {
            Sala s = unitOfWork.Sala.NadjiPoId(request.SalaId);
            ProjekcijaViewModel model = new ProjekcijaViewModel
            {
                Num = request.Num,
                SalaId = request.SalaId,
                NazivSale = s.NazivSale,
                Slobodna = s.Slobodna
            };
            return PartialView("ProjekcijaPartial",model);
        }

    }
}