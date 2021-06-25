using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bioskop.Podaci.Implementacija
{
    public class RepositoryProjekcija : IRepositoryProjekcija
    {
        private BioskopContext context;

        public RepositoryProjekcija(BioskopContext context)
        {
            this.context = context;
        }
        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Projekcija s)
        {
            List<Sediste> sedista = context.Sediste.Where(x => x.ProjekcijaId == s.ProjekcijaId).ToList();
            if (sedista != null)
            {
                foreach (Sediste sed in sedista)
                {
                    context.Sediste.Remove(sed);
                }
            }

            context.Projekcija.Remove(s);
        }
        public void izbrisiSvePFilm(int id, List<Projekcija> projekcije)
        {
            List<Karta> karte = context.Karta.ToList();
            if (projekcije.Count == 0) return;
            foreach (Projekcija p in projekcije)
            {
                foreach (Karta k in karte)
                {
                    if (k.ProjekcijaId == p.ProjekcijaId)
                    {
                        context.Karta.Remove(k);
                    }
                }
                if (p.FilmId == id)
                {
                   Delete(p);
                }
            }
        }
        public void izbrisiSvePSala(int id, List<Projekcija> projekcije)
        {
            List<Karta> karte = context.Karta.ToList();

            if (projekcije.Count == 0) return;
            foreach (Projekcija p in projekcije)
            {
                foreach (Karta k in karte)
                {
                    if (k.ProjekcijaId == p.ProjekcijaId)
                    {
                        context.Karta.Remove(k);
                    }
                }
                if (p.SalaId == id)
                {
                    Delete(p);
                }
            }

        }
        public void Dodaj(Projekcija s)
        {
            context.Projekcija.Add(s);
        }

        public void DodajProjekcije(List<Projekcija> listProjekcija, List<Projekcija> postojecePROJEKCIJE)
        {
            foreach (Projekcija p in listProjekcija) {

                if (postojecePROJEKCIJE.Any(pp => pp.SalaId == p.SalaId))
                {
                    List<Projekcija> listaIsteSale = postojecePROJEKCIJE.Where(pp => pp.SalaId == p.SalaId).ToList();
                    foreach (Projekcija ls in listaIsteSale) {
                        if ((p.VremeProjekcije >= ls.VremeProjekcije && p.VremeProjekcije <= ls.VremeKrajaProjekcije) ||
                            (p.VremeKrajaProjekcije >= ls.VremeProjekcije && p.VremeKrajaProjekcije <= ls.VremeKrajaProjekcije)) {
                            throw new Exception();
                        }
                    }
                    context.Projekcija.Add(p);
                }
                else {
                    context.Projekcija.Add(p);
                }

            }
         
        }

        public Projekcija NadjiPoId(int id)
        {
            return context.Projekcija.Find(id);
        }

        public void Update(Projekcija s)
        {
            throw new NotImplementedException();
        }

        public List<Projekcija> VratiSve()
        {
            return context.Projekcija.ToList();
        }

        public List<Projekcija> VratiSveSaId(int id)
        {
            return context.Projekcija.Where(p => p.FilmId == id).ToList();
        }
    }
}