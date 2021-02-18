using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bioskop.Domen;
using Bioskop.Podaci.UnitOfWork.Korisnici;
using Bioskop.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace Bioskop.WebApp.Controllers
{
    public class KorisnikController : Controller
    {
        private readonly IKorisniciUnitOfWork unitOfWork;

        public KorisnikController(IKorisniciUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Korisnik
        [ActionName("Login")]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                Korisnik korisnik = unitOfWork.Korisnici.GetByUsernameAndPassword(new Korisnik
                {
                    Username = model.Username,
                    Password = model.Password
                });
                //ViewBag.IsLoggedIn = true;
                HttpContext.Session.SetInt32("userid", korisnik.KorisnikId);
                HttpContext.Session.SetString("username", korisnik.Username);
                HttpContext.Session.Set("user", System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(korisnik));
                // serijalizacija celog objekta u ime sesije
                return RedirectToAction("Index", "Film");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Pogresna sifra ili username.");
                return View();
            }
        }



        // GET: Korisnik/Create
        [ActionName("Register")]
        public ActionResult Create()
        {
            return View("Register");
        }

        // POST: Korisnik/Create
        [ActionName("Register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterViewModel model)
        {
            try
            {
                bool exist = unitOfWork.Korisnici.VecPostoji(model.Username);
                if (exist) throw new Exception();
                Korisnik k = new Korisnik {
                    Ime = model.Ime,
                    Prezime=model.Prezime,
                    Username=model.Username,
                    Password=model.Password,
                    Pol=model.Pol
                };
                unitOfWork.Korisnici.Dodaj(k);
                unitOfWork.Commit();
                return RedirectToAction("Login");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Korisnik sa ovim korisnickim imenom," +
                    "vec postoji.");
                return View();
            }
        }



        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}