using Bioskop.Domen;
using Bioskop.Podaci.UnitOfWork;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Classes
{
    /// <inheritdoc/>
    /// <summary>
    ///Represent class for business logic with Films

    /// </summary>
    public class FilmService : IFilmService
    {
        /// <summary>
        /// Constructor that initialize UnitOfWork
        /// </summary>
        public IUnitOfWork uow { get; set; }
        public FilmService(IUnitOfWork uow) => this.uow = uow;

        public void Add(Film film)
        {
            throw new NotImplementedException();
        }

        public Film Find(int? filmId)
        {
            throw new NotImplementedException();
        }
    }
}
