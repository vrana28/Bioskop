using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bioskop.Podaci;
using System.Linq.Expressions;

namespace Bioskop.Podaci.Implementacija
{
    public class RepositoryFilm : IRepositoryFilm
    {
        private BioskopContext context;

        public RepositoryFilm(BioskopContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Film s)
        {
            context.Film.Remove(s);
        }

        public void Dodaj(Film s)
        {
            context.Film.Add(s);
        }

        public Film NadjiPoId(int id)
        {
            return context.Film.Find(id);
        }

        public List<Film> Search(Expression<Func<Film, bool>>p)
        {
            return context.Film.Where(p).ToList();
        }

        public void Update(Film s)
        {
            throw new NotImplementedException();
        }

        public List<Film> VratiSve()
        {
            return context.Film.ToList();
        }
    }
}
