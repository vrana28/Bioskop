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
        int BrojSlobodnihSedista(int salaId);
        void DodajSedistaZaProjekciju(List<Projekcija> listProjekcija);
    }
}
