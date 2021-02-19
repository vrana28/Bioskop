using Bioskop.Domen;
using Bioskop.Podaci;
using Bioskop.Podaci.Implementacija;
using Bioskop.Podaci.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BioskopKonzolnaApp
{
    class Program
    {
        static BioskopContext context = new BioskopContext();
        static void Main(string[] args)
        {
            //VratiSveFilmove();
            //DodajFilm();
            //VratiFilmoveISaleukojimaSeOdrzavajuProjectionQuery();
            //IRepositoryFilm repositoryFilm = new RepositoryFilm(context);
            //repositoryFilm.Dodaj(new Film { Naziv = "Proba" });

            using IUnitOfWork uow = new BioskopUnitOfWork(new BioskopContext());
            uow.Film.Dodaj(new Film{ Naziv ="Alisa u zemlji Cuda",Godina=2008,Reziser="Pera",Trajanje=95,Zanr = Zanr.Komedija});
            //uow.Korisnik.Delete(context.Korisnik.First());
            uow.Commit();

        }

        public static void DodajFilm()
        {
            BioskopContext context = new BioskopContext(); // predstavlja brokera baze podataka
            context.Add(new Sediste
            {

            });
            context.Add(new Korisnik
            {
                Ime = "Lana",
                Prezime = "Lanic",
                Pol = Pol.Ženski,
                Username = "lana",
                Password = "lana"
            });
            context.Add(new Korisnik
            {
                Ime = "Mica",
                Prezime = "Micic",
                Pol = Pol.Muški,
                Username = "mica",
                Password = "mica"
            });
            // fali nam Commit, sve se radi preko transakcija
            // transakcije se izvrsavaju sve ili nijedna
            context.SaveChanges(); // ovo je komitovanje
        //    context.Dispose();
        }

        public static void VratiSveFilmove()
        {
            using BioskopContext context = new BioskopContext(); // predstavlja brokera baze podataka
            // automatski ce se izvrsavai Dispose - oslobadjanje resursa
            List<Film> result = context.Film.ToList();
            result.ForEach(f => Console.WriteLine(f));
        }

        // pravimo where upit
        public static void VratiSveFilmoveWhere()
        {
            using BioskopContext context = new BioskopContext(); // predstavlja brokera baze podataka
            // automatski ce se izvrsavai Dispose - oslobadjanje resursa
            List<Film> result = context.Film.Where(f => f.Naziv.Contains("Sh")).ToList();
            result.ForEach(f => Console.WriteLine(f));
        }

        // Update tracking i update no tracking
        public static void Update()
        {

            List<Film> filmovi = context.Film.ToList();
            Film filmZaUpdate = filmovi.First();
            filmZaUpdate.Naziv = "Shrek i zmajevi 2";
            context.Update(filmZaUpdate); // azuriranje bez trackinga, kada nema onda zna da li je bilo
            //promene ili ne...
            context.SaveChanges();
        }

        public static void AddProjekcija()
        {

            Projekcija p = new Projekcija
            {

                FilmId = 1,
                SalaId = 2,
                Cena = 300,
                VremeProjekcije = new DateTime(2021, 2, 15),

            };
            context.Add(p);
            context.SaveChanges();
        }

        // metoad DBSeta - Film f = context.Film.Find(1);

        public static void VratiProjekcije()
        {
            // kada bi koristili JOIN, koristimo INCLUDE
            List<Projekcija> p = context.Projekcija.Include(p => p.Sala).Include(p => p.Film).ToList();
            p.ForEach(pro => Console.WriteLine(pro));

        }
       // brisanje bez trackinga
        public static void Delete()
        {

            //List<Karta> karte = context.Karta.Include(k => k.Sediste).Include(k => k.Korisnik).Include(k => k.Projekcija).ToList();
            //Karta k = karte[0];
            //BioskopContext newContext = new BioskopContext();
            //newContext.Attach(k);
            //newContext.Entry(k.Sediste).State = EntityState.Deleted;
            //newContext.SaveChanges();
        }

        /*UPDATE ONLY DEPARTMENT NO TRACKING
        za azuriranje dela odnosno, jedne klase koje su povezane

            List<Subjects> subjectsWithDepartment = context.Subjects.Include(s=>s.Department).ToList();
            using StudentContext = subjectsWithDepartment[0];
            ---------------------------------
            newContext.Attach(s); prikljucujemo, odnosno kazemo da je deo konteksta
            ---------------------------------
            ---------------------------------
            s.Department.Name = "Department Update No Tracking";
            ---------------------------------
            ---------------------------------
            newContext.Entry(s.Department).State = EntityState.Modified; - menjanje stanja
            ---------------------------------
            newContext.SaveChanges();

        */
        // slozen query
        public static void VratiFilmoveISaleukojimaSeOdrzavaju() {

            foreach (Film f in context.Film.Include(s=>s.Sale).ThenInclude(p=>p.Sala)) {
                Console.WriteLine(f);
            }
        
        }

        public static void VratiFilmoveISaleukojimaSeOdrzavajuProjectionQuery()
        {
            var film = context.Film
                .Select(f =>
                new
                {
                    f.Naziv,
                    f.Godina,
                    Sale = f.Sale.Select(s => s.Sala)
                }).ToList();
            Console.WriteLine(film);
        }

    }
}
