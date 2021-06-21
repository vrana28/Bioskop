using System;
using System.Collections.Generic;
using System.Linq;
using Bioskop.Domen;
using Bioskop.Podaci.UnitOfWork;
using Bioskop.Podaci.UnitOfWork.Korisnici;
using Bioskop.WebApp.Filters;
using Bioskop.WebApp.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Bioskop.WebApp.Controllers
{
    /// <summary>
    /// Controller for Ticket (Karta) class
    /// </summary>
    [LoggedInKorisnik]
    public class KartaController : Controller
    {
        /// <value>Represent unit of work</value>
        private readonly IUnitOfWork unitOfWork;
        private readonly IKorisniciUnitOfWork unitOfWorkKorisnik;
        /// <value>Represent ticket as class Karta</value>
        public Karta Karta { get; set; }
        public KartaController(IUnitOfWork unitOfWork, IKorisniciUnitOfWork unitOfWorkKorisnik)
        {
            this.unitOfWork = unitOfWork;
            this.unitOfWorkKorisnik = unitOfWorkKorisnik;
        }
        /// <summary>
        /// Returns index page
        /// </summary>
        /// <returns>Model as index page</returns>
        // GET: Karta
        public ActionResult Index()
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View("Index");
        }

        /// <summary>
        /// Returns selected id of ticket
        /// </summary>
        /// <param name="id">Ticket id as int</param>
        /// <returns>Model</returns>
        // GET: Karta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Creating model of Ticket
        /// </summary>
        /// <param name="id">Projekcija id as int</param>
        /// <returns>Model with all needed data</returns>
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
            ViewBag.SlobodnaSedista = unitOfWork.Sediste.BrojSlobodnihSedista(s.SalaId,p.ProjekcijaId);
            CreateKartaViewModel model = new CreateKartaViewModel
            {
                Karta = k,
                KorisnikId = k.Korisnik.KorisnikId,
                ProjekcijaId = k.Projekcija.ProjekcijaId,
                BrojKarti=0
            };
            return View(model);
        }

        /// <summary>
        /// Creating list of tickets so we can make reservation and send it to client.
        /// </summary>
        /// <param name="model">Model of all neded information</param>
        /// <returns>Redirect to same page if mistake, or projection page if successfully</returns>
        // POST: Karta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateKartaViewModel model)
        {
            try
            {
                if (model.BrojKarti > 4) throw new Exception("Ne mozete vise od 4 karte");
                Projekcija p = unitOfWork.Projekcija.NadjiPoId(model.ProjekcijaId);
                Korisnik k = unitOfWorkKorisnik.Korisnici.NadjiPoId(model.KorisnikId);
                Sala sala = unitOfWork.Sala.NadjiPoId(p.SalaId);
                Film f = unitOfWork.Film.NadjiPoId(p.FilmId);
                List<string> karte = new List<string>();
                List<Sediste> listaSedista = unitOfWork.Sediste.VratiSvaSlobodnaMesta(p.ProjekcijaId, p.SalaId);
                if (model.BrojKarti > listaSedista.Count) throw new Exception();
                listaSedista = listaSedista.Take(model.BrojKarti).ToList();
                List<string> rezervacija = new List<string>();
                rezervacija = unitOfWork.Karta.Rezervisi(listaSedista, k, p);

                unitOfWork.Commit();
                string rezerv = "";
                foreach (string rez in rezervacija)
                {
                    rezerv += rez + "\n";
                }
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Bioskop WebApp", "maredjuric155@gmail.com"));
                message.To.Add(new MailboxAddress(k.Ime + " " + k.Prezime, k.Email));
                message.Subject = $"Rezervacija za {f.Naziv}";
                message.Body = new TextPart("plain")
                {
                    Text = "REZERVACIJA \n\n"
                    + $"Film :{f.Naziv} \n"
                    + $"Sala: {sala.NazivSale} \n"
                    + $"Vreme pocetka projekcije: {p.VremeProjekcije} \n"
                    + $"Vreme kraja projekcije: {p.VremeKrajaProjekcije}\n"
                    + $"Broj karti:{model.BrojKarti} \n"
                    + $"{rezerv}\n Pozdrav, Bioskop WebApp"
                    //Text += $"Red i kolona: {rezervacija[0]}";
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("maredjuric155@gmail.com", "Testtest12345");
                    client.Send(message);
                    client.Disconnect(true);
                }

                return RedirectToAction("Index", "Film");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Greska");
                return RedirectToAction("Create");
            }
        }

        /// <summary>
        /// Edit Ticket
        /// </summary>
        /// <param name="id">Represent id of ticket as int</param>
        /// <returns>Model view</returns>
        // GET: Karta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Karta/Edit/5
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
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
        /// Deleting ticket
        /// </summary>
        /// <param name="id">Ticket id as int</param>
        /// <returns>Model</returns>
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