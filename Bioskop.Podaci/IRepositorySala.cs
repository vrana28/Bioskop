using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Podaci
{
    public interface IRepositorySala : IRepository<Sala>
    {
        void DodajSvaSedista(Sala sala);
    }
}
