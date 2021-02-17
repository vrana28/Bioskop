using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bioskop.Podaci.Implementacija
{
    public class RepositoryKorisnik : IRepositoryKorisnik
    {
        private BioskopContext context;
        public RepositoryKorisnik(BioskopContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Korisnik s)
        {
            context.Korisnik.Remove(s);
        }

        public void Dodaj(Korisnik s)
        {
            context.Korisnik.Add(s);
        }

        public Korisnik NadjiPoId(int id)
        {
            return context.Korisnik.Find(id);
        }

        public void Update(Korisnik s)
        {
            throw new NotImplementedException();
        }

        public List<Korisnik> VratiSve()
        {
            return context.Korisnik.ToList();
        }
    }
}
