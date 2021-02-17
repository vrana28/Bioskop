using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bioskop.Podaci.Implementacija
{
    public class RepositorySala : IRepositorySala
    {
        private BioskopContext context;

        public RepositorySala(BioskopContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Sala s)
        {
            context.Sala.Remove(s);
        }

        public void Dodaj(Sala s)
        {
            context.Sala.Add(s);
        }

        public Sala NadjiPoId(int id)
        {
            return context.Sala.Find(id);
        }

        public void Update(Sala s)
        {
            throw new NotImplementedException();
        }

        public List<Sala> VratiSve()
        {
            return context.Sala.ToList();
        }
    }
}
