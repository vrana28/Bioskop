using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface that manager working with BookService
    /// </summary>
    public interface IFilmService
    {
        /// <summary>
        /// Return all films
        /// </summary>
        /// <returns>List of Films</returns>
        List<Film> GetAll();
        /// <summary>
        /// Finds film by filmId
        /// </summary>
        /// <param name="filmId">Film id as int</param>
        /// <returns> Film</returns>
        Film Find(int? filmId);
        /// <summary>
        /// Adds film in database
        /// </summary>
        void Add(Film f);
    }
}
