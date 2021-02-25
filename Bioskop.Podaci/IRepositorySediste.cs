using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Podaci
{
    public interface IRepositorySediste:IRepository<Sediste>
    {
        public int VratiBrojKolona(Sala s);
        List<Sediste> VratiSvePoId(int salaId);
        int BrojSlobodnihSedista(int salaId, int projekcijaId);
        void DodajSedistaZaProjekciju(List<Projekcija> listProjekcija);
        List<Sediste> VratiSvaSlobodnaMesta(int projekcijaId, int salaId);
        void izbrisiSvaSedistaP(List<Sediste> sedista, Projekcija p);
    }
}
