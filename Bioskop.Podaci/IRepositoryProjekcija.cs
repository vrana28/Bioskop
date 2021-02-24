using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Podaci
{
    public interface IRepositoryProjekcija : IRepository<Projekcija>
    {
        List<Projekcija> VratiSveSaId(int id);
        void DodajProjekcije(List<Projekcija> listProjekcija);
    }
}
