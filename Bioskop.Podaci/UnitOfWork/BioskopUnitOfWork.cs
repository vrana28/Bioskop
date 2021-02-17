using Bioskop.Domen;
using Bioskop.Podaci.Implementacija;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Podaci.UnitOfWork
{
    public class BioskopUnitOfWork : IUnitOfWork
    {
        private BioskopContext context;

        public BioskopUnitOfWork(BioskopContext context)
        {
            this.context = context;
            Film = new RepositoryFilm(this.context);
            Sala = new RepositorySala(this.context);
            Karta = new RepositoryKarta(this.context);
            Korisnik = new RepositoryKorisnik(this.context);
            Projekcija = new RepositoryProjekcija(this.context);
        }
        public IRepositoryFilm Film { get; set; }
        public IRepositorySala Sala { get; set; }
        public IRepositoryKarta Karta { get; set; }
        public IRepositoryKorisnik Korisnik { get; set; }
        public IRepositoryProjekcija Projekcija { get; set; }
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
