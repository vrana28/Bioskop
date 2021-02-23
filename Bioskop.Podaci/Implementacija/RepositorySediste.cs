using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bioskop.Podaci.Implementacija
{
    public class RepositorySediste : IRepositorySediste
    {
        private BioskopContext context;

        public RepositorySediste(BioskopContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(Sediste s)
        {
            throw new NotImplementedException();
        }
        public void Dodaj(Sediste s)
        {
            context.Sediste.Add(s);
        }

        public Sediste NadjiPoId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Sediste s)
        {
            throw new NotImplementedException();
        }
        public List<Sediste> VratiSve()
        {
            throw new NotImplementedException();
        }
        public int VratiBrojKolona(Sala sala)
        {
            return sala.SedistaUSali.Count;
        }

        public List<Sediste> VratiSvePoId(int salaId)
        {
            return context.Sediste.Where(s => s.SalaId == salaId).ToList();
        }
    }
}
