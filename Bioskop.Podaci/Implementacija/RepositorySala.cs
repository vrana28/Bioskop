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

        public void DodajSvaSedista(Sala sala)
        {
            int bk = sala.BrojKolona + 1;
            int br = sala.BrojRedova + 1;
            for (int i = 1; i < bk; i++)
            {
                for (int j = 1; j < br; j++)
                {
                    char r = (char)(j + 'a' - 1);
                    context.Sediste.Add(new Sediste { Kolona = i, Red = r, Sala = sala, SalaId = sala.SalaId });
                }

            }
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
