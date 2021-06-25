using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bioskop.Domen
{
    /// <summary>
    /// Represent Projection class
    /// </summary>
    public class Projekcija
    {
        /// <value>Represent Projection id as int</value>
        public int ProjekcijaId { get; set; }
        /// <value>Represent hall as object Hall</value>
        public Sala Sala { get; set; }
        /// <value>Represent hall id as int</value>
        public int SalaId { get; set; }
        /// <value>Represent film as object Film</value>
        public Film Film { get; set; }
        /// <value>Represent film id as int</value>
        public int FilmId { get; set; }
        /// <value>Represent begin time of projection as dateTime</value>
        public DateTime VremeProjekcije { get; set; }
        /// <value>Represent end time of projection as dateTime</value>
        public DateTime VremeKrajaProjekcije { get; set; }
        /// <value>Represent price of chosen projection as double</value>
        public double  Cena { get; set; }
        /// <returns>Returns informations about Projection as string</returns>
        public override string ToString()
        {
            return $"Naziv sale:{Sala.NazivSale}; Naziv: {Film.Naziv};Vreme projekcije: {VremeProjekcije}; Cena: {Cena}";
        }
    }
}
