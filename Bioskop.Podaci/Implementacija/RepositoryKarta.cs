using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bioskop.Podaci.Implementacija
{
    public class RepositoryKarta : IRepositoryKarta
    {
        private BioskopContext context;
        public RepositoryKarta(BioskopContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Karta s)
        {
            context.Karta.Remove(s);
        }

        public void Dodaj(Karta s)
        {
            context.Karta.Add(s);
        }

        public Karta NadjiPoId(int id)
        {
            return context.Karta.Find(id);
        }

        public void Update(Karta s)
        {
            throw new NotImplementedException();
        }

        public List<Karta> VratiSve()
        {
            return context.Karta.ToList();
        }
    }
}
