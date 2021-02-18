using Bioskop.Domen;
using Bioskop.Podaci.Implementacija;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Podaci.UnitOfWork.Korisnici
{
    public class KorisniciUnitOfWork : IKorisniciUnitOfWork
    {
        private readonly KorisnikContext context;

        public KorisniciUnitOfWork(KorisnikContext context)
        {
            this.context = context;
            Korisnici = new RepositoryKorisnik(this.context);
        }
        public IRepositoryKorisnik Korisnici { get ; set ; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
