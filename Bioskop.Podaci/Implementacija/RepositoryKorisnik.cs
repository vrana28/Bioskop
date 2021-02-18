using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bioskop.Podaci.Implementacija
{
    public class RepositoryKorisnik : IRepositoryKorisnik
    {
        private KorisnikContext context;
        public RepositoryKorisnik(KorisnikContext context)
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

        public Korisnik GetByUsernameAndPassword(Korisnik k)
        {
            return context.Korisnik.Single(s => s.Username == k.Username && s.Password == k.Password);
        }

        public Korisnik NadjiPoId(int id)
        {
            return context.Korisnik.Find(id);
        }

        public void Update(Korisnik s)
        {
            throw new NotImplementedException();
        }

        public bool VecPostoji(string username)
        {
            return context.Korisnik.Any(k => k.Username == username);
        }

        public List<Korisnik> VratiSve()
        {
            return context.Korisnik.ToList();
        }
    }
}
