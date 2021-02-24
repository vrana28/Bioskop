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
            List<Sediste> sedista = context.Sediste.Where(x=>x.ProjekcijaId==s.ProjekcijaId ).ToList();
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
        foreach (Projekcija p in projekcije)
        {
            if (p.FilmId == id)
            {
                context.Projekcija.Remove(p);
            }
        }
    }
        public void izbrisiSvePSala(int id, List<Projekcija> projekcije)
        {
            if (projekcije.Count == 0) return;
            foreach (Projekcija p in projekcije)
            {
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

        public void DodajProjekcije(List<Projekcija> listProjekcija)
        {
            foreach (Projekcija pr in listProjekcija)
            {
              /*   if (l.All(x => (p.VremeProjekcije <= x.VremeProjekcije && p.VremeProjekcije >= x.VremeKrajaProjekcije && x.SalaId == p.SalaId) || x.SalaId != p.SalaId) ||
                 l.All(x1 => (p.VremeProjekcije >= x1.VremeProjekcije && p.VremeProjekcije >= x1.VremeKrajaProjekcije && x1.SalaId == p.SalaId) || x1.SalaId != p.SalaId) || l.Count == 0)
                 {*/
                context.Projekcija.Add(pr);
         //   }
        
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
