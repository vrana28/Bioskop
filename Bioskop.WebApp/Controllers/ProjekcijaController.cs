using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Bioskop.Podaci.UnitOfWork;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Text.Json.Serialization;
using Bioskop.WebApp.Models;
using Bioskop.Domen;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bioskop.WebApp.Filters;

namespace Bioskop.WebApp.Controllers
{
    [LoggedInKorisnik]
    public class ProjekcijaController : Controller
    {
        public List<GoogleCalendarViewModel> GoogleEvents = new List<GoogleCalendarViewModel>();
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        private readonly IUnitOfWork unitOfWork;
        
        public ProjekcijaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Projekcija
        public ActionResult Index()
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            List<Projekcija> model = unitOfWork.Projekcija.VratiSve();
            foreach (Projekcija p in model) {
                p.Film = unitOfWork.Film.NadjiPoId(p.FilmId);
                p.Sala = unitOfWork.Sala.NadjiPoId(p.SalaId);
            };
            model = model.OrderBy(x => x.VremeProjekcije).ToList();
            return View(model);
        }

        

        public void CalendarDogadjaji() {

            UserCredential credential;
            //string path = System.Web.Hosting.HostingEnvironment.MapPath("Credentials.json");
            using (var stream =
                new FileStream("Credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    var googlecalendar = new GoogleCalendarViewModel();
                    googlecalendar.Projekcija = new Projekcija {
                        VremeProjekcije = (DateTime)eventItem.Start.DateTime,
                        VremeKrajaProjekcije = (DateTime)eventItem.End.DateTime,
                        Cena = double.Parse(eventItem.Summary)
                    };
                    GoogleEvents.Add(googlecalendar);
                }
            }
            

        }

        // GET: Projekcija/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            List<Projekcija> model = unitOfWork.Projekcija.VratiSveSaId(id);
            foreach (Projekcija p in model)
            {
                p.Film = unitOfWork.Film.NadjiPoId(p.FilmId);
                p.Sala = unitOfWork.Sala.NadjiPoId(p.SalaId);
            };
            return View("Index",model.OrderBy(x=>x.VremeProjekcije).ToList());
        }

        // GET: Projekcija/Create
        public ActionResult Create()
        {
            List<Sala> listSala = unitOfWork.Sala.VratiSve();
            List<Film> listFilmova = unitOfWork.Film.VratiSve();
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            List<SelectListItem> selectList1 = listSala.Select(s => new SelectListItem { Text = s.NazivSale, Value = s.SalaId.ToString() }).ToList();
            List<SelectListItem> selectList2 = listFilmova.Select(s => new SelectListItem { Text = s.Naziv, Value = s.FilmId.ToString() }).ToList();
            GoogleCalendarViewModel model = new GoogleCalendarViewModel
            {
                Sale = selectList1,
                Filmovi = selectList2

            };
            CalendarDogadjaji();
            ViewBag.EventList = GoogleEvents;
            return View(model);
        }

        // POST: Projekcija/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] GoogleCalendarViewModel model)
        {
            try
            {
                CalendarDogadjaji();

                List<Projekcija> listProjekcija = new List<Projekcija>();
                if (GoogleEvents.Count == 0) throw new Exception();
                List<Projekcija> postojeceProjekcije = new List<Projekcija>();
                postojeceProjekcije = unitOfWork.Projekcija.VratiSve();
                foreach (var item in GoogleEvents)
                {

                    Projekcija p = new Projekcija
                    {

                        VremeKrajaProjekcije = item.Projekcija.VremeKrajaProjekcije,
                        VremeProjekcije = item.Projekcija.VremeProjekcije,
                        Cena = item.Projekcija.Cena,
                        SalaId = model.Projekcija.SalaId,
                        FilmId = model.Projekcija.FilmId
                    };

                    listProjekcija.Add(p);

                }

                unitOfWork.Projekcija.DodajProjekcije(listProjekcija, postojeceProjekcije);
                unitOfWork.Commit();
                unitOfWork.Sediste.DodajSedistaZaProjekciju(listProjekcija);
                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Create");
            }
        }

        // GET: Projekcija/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Projekcija/Edit/5
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

        // GET: Projekcija/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.Username = HttpContext.Session.GetString("username");
            Projekcija p = unitOfWork.Projekcija.NadjiPoId(id);
            List<Karta> karte = unitOfWork.Karta.VratiSve();
            List<Sediste> sedista = unitOfWork.Sediste.VratiSve();
            unitOfWork.Karta.IzbrisiSveIzP(karte, p);
            unitOfWork.Sediste.izbrisiSvaSedistaP(sedista, p);
            unitOfWork.Projekcija.Delete(p);
            unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        // POST: Projekcija/Delete/5
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