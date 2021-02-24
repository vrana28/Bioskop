using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bioskop.Podaci.Implementacija
{
    public class RepositorySediste : IRepositorySediste
    {
        private BioskopContext context;

        public RepositorySediste(BioskopContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(Sediste s)
        {
            throw new NotImplementedException();
        }
        public void Dodaj(Sediste s)
        {
            context.Sediste.Add(s);
        }

        public Sediste NadjiPoId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Sediste s)
        {
            Sediste nova = new Sediste
            {
                Red = s.Red,
                Kolona = s.Kolona,
                ProjekcijaId = s.ProjekcijaId,
                SalaId = s.SalaId,
                SlobodnoSediste=false,
            };
            context.Sediste.Remove(s);
            context.Sediste.Add(nova);
        }
        public List<Sediste> VratiSve()
        {
            throw new NotImplementedException();
        }
        public int VratiBrojKolona(Sala sala)
        {
            return sala.SedistaUSali.Count;
        }

        public List<Sediste> VratiSvePoId(int salaId)
        {
            return context.Sediste.Where(s => s.SalaId == salaId).ToList();
        }

        public int BrojSlobodnihSedista(int salaId, int projekcijaId)
        {
            return context.Sediste.Where(s => s.SalaId == salaId && s.ProjekcijaId==projekcijaId && s.SlobodnoSediste==true).Count();
        }

        public void DodajSedistaZaProjekciju(List<Projekcija> listProjekcija)
        {
           
            foreach (Projekcija p in listProjekcija)
            {
                Sala s = context.Sala.Find(p.SalaId);
                int bk = s.BrojKolona + 1;
                int br = s.BrojRedova + 1;
                for (int i = 1; i < bk; i++)
                {
                    for (int j = 1; j < br; j++)
                    {
                        char r = (char)(j + 'a' - 1);
                        context.Sediste.Add(new Sediste { SlobodnoSediste=true,Kolona = i, Red = r, Sala = s,ProjekcijaId=p.ProjekcijaId, SalaId = p.SalaId });
                    }

                } 
            }
        }

        public List<Sediste> VratiSvaSlobodnaMesta(int projekcijaId, int salaId)
        {
            return context.Sediste.Where(s => s.ProjekcijaId == projekcijaId && s.SalaId == salaId && s.SlobodnoSediste == true).ToList();
        }
    }
}
