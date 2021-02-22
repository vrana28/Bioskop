using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Podaci.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    { // ovde i disposable - oslobadjanje resursa
        public IRepositoryFilm Film{ get; set; }
        public IRepositorySala Sala{ get; set; }
        public IRepositoryKarta Karta { get; set; }
        public IRepositoryProjekcija Projekcija { get; set; }
        public IRepositorySediste Sediste { get; set; }
        void Commit();
    }
}
