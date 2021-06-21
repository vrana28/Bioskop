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
    /// <summary>
    /// Represent controller for User class
    /// </summary>
    public class KorisnikController : Controller
    {
        /// <values>Unit of work</values>
        private readonly IKorisniciUnitOfWork unitOfWork;
        public KorisnikController(IKorisniciUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns login page
        /// </summary>
        /// <returns>Login page</returns>
        // GET: Korisnik
        [ActionName("Login")]
        public ActionResult Index()
        {
            return View("Login");
        }

        /// <summary>
        /// Login and checking credentials
        /// </summary>
        /// <param name="model">Model as User (Korisnik)</param>
        /// <returns>Redirect to dashboard if successfuly or login page if mistake has been made</returns>
        /// <exception cref="Exception">When credentials are not good</exception>
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

        /// <summary>
        /// Registering new user to database after validation.
        /// </summary>
        /// <param name="model">Model of User as RegisterViewModel</param>
        /// <returns></returns>
        /// <exception cref="Exception">When user we enter already exist with that parametar</exception>
        // POST: Korisnik/Create
        [ActionName("Register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterViewModel model)
        {
            try
            {
                if (model.Ime == null || model.Prezime == null || model.Username == null || model.Password == null || model.Email == null) throw new Exception();
                bool exist = unitOfWork.Korisnici.VecPostoji(model.Username,model.Email);
                if (exist) throw new Exception();
                Korisnik k = new Korisnik {
                    Ime = model.Ime,
                    Prezime=model.Prezime,
                    Email = model.Email,
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
                ModelState.AddModelError(string.Empty, "Losi parametri ili korisnik vec postoji");
                return View();
            }
        }


        /// <summary>
        /// Clearing session and log out from Cinema interface.
        /// </summary>
        /// <returns>Redirect to Login page</returns>
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}