using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Podaci
{
    public interface IRepositoryKorisnik:IRepository<Korisnik>
    {
        Korisnik GetByUsernameAndPassword(Korisnik k);
        bool VecPostoji(string username, string email);
    }
}
