using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bioskop.Podaci.Implementacija
{
    public class RepositoryKarta : IRepositoryKarta
    {
        private BioskopContext context;
        public RepositoryKarta(BioskopContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Karta s)
        {
            context.Karta.Remove(s);
        }

        public void Dodaj(Karta s)
        {
            context.Karta.Add(s);
        }

        public void IzbrisiSveIzP(List<Karta> karte, Projekcija p)
        {
            foreach (Karta k in karte)
            {
                if (k.ProjekcijaId == p.ProjekcijaId)
                {
                    context.Karta.Remove(k);
                }
            }
        }

        public Karta NadjiPoId(int id)
        {
            return context.Karta.Find(id);
        }

        public List<string> Rezervisi(List<Sediste> listaSedista, Korisnik k, Projekcija p)
        {
            List<string> rezervacija = new List<string>();
            foreach (Sediste s in listaSedista)
            {
                Karta karta = new Karta
                {
                    KorisnikId = k.KorisnikId,
                    ProjekcijaId = p.ProjekcijaId,
                    RedKolona = "Red:" + s.Red + " " + "Kolona:" + s.Kolona.ToString()
                };
                rezervacija.Add(karta.RedKolona);
                context.Karta.Add(karta);
                Sediste nova = new Sediste
                {
                    Red = s.Red,
                    Kolona = s.Kolona,
                    ProjekcijaId = s.ProjekcijaId,
                    SalaId = s.SalaId,
                    SlobodnoSediste = false,
                };
                context.Sediste.Remove(s);
                context.Sediste.Add(nova);
            }
            return rezervacija;
        }

        public void Update(Karta s)
        {
            throw new NotImplementedException();
        }

        public List<Karta> VratiSve()
        {
            return context.Karta.ToList();
        }
    }
}
