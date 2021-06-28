using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface that manager working with FilmService
    /// </summary>
    public interface IFilmService : IService
    {

        /// <summary>
        /// Finds film by filmdId
        /// </summary>
        /// <param name="filmId">Film id as int</param>
        /// <returns>Film</returns>
        Film Find(int? filmId);

        /// <summary>
        /// Add film in database
        /// </summary>
        /// <param name="film">Film that need to be saved in database</param>
        /// 
        void Add(Film film);


    }
}
