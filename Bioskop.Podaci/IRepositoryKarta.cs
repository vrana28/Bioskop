using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Podaci
{
    public interface IRepositoryKarta : IRepository<Karta>
    {
        void IzbrisiSveIzP(List<Karta> karte, Projekcija p);
        List<string> Rezervisi(List<Sediste> listaSedista, Korisnik k, Projekcija p);
    }
}
