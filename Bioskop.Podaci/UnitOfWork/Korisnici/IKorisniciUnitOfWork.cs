using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Podaci.UnitOfWork.Korisnici
{
    public interface IKorisniciUnitOfWork:IDisposable
    {
        public IRepositoryKorisnik Korisnici{ get; set; }
        void Commit();
    }
}
