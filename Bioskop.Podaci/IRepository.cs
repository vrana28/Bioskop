using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Podaci
{
    public interface IRepository<T>
    {
        void Dodaj(T s);
        List<T> VratiSve();
        T NadjiPoId(int id);
        void Delete(T s);
        void Update(T s);
        void Commit();
    }



}
