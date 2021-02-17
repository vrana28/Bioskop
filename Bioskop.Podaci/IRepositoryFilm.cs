using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bioskop;
using Bioskop.Domen;

namespace Bioskop.Podaci
{
    // Repository patern
    public interface IRepositoryFilm : IRepository<Film>
    {
        List<Film> Search(Expression<Func<Film,bool>> p);
    }
}
