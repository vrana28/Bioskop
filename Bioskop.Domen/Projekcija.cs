using EShop.Model.Exceptions;
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
        /// <exception cref="ArgumentOutOfRangeException">Throws when vreme projekcije is null or wrong</exception>
        private DateTime vremeProjekcije;
        public DateTime VremeProjekcije {
            get {return vremeProjekcije; }
            set { if(value <= DateTime.Now) throw new  ArgumentOutOfRangeException("Lose vreme pocetka projekcije.");
                vremeProjekcije = value;
            }
        }
        /// <value>Represent end time of projection as dateTime</value>
        /// <exception cref="ArgumentOutOfRangeException">Throws when vreme kraja projekcije is null or wrong</exception>
        /// <exception cref="ProjekcijaException">Throws when vreme kraja projekcije is before vreme projekcije</exception>
        private DateTime vremeKrajaProjekcije;
        public DateTime VremeKrajaProjekcije
        {
            get { return vremeKrajaProjekcije; }
            set
            {
                if (value <= DateTime.Now ) throw new ArgumentOutOfRangeException("Lose vreme kraja projekcije.");
                if (value <= vremeProjekcije) throw new ProjekcijaException("Ne moze kraj prejekcije da bude pre pocetka projekcije.");
                vremeKrajaProjekcije = value;
            }
        }
        /// <value>Represent price of chosen projection as double</value>
        /// <exception cref="ArgumentOutOfRangeException">Throws when cena projekcije is negative.</exception>
        private double cena;
        public double  Cena {
            get { return cena; }
            set {
                if(value <= 0) throw new ArgumentOutOfRangeException("Cena ne moze biti negativna.");
                cena = value;    }
        }
        /// <returns>Returns informations about Projection as string</returns>
        public override string ToString()
        {
            return $"Naziv sale:{Sala.NazivSale}; Naziv: {Film.Naziv};Vreme projekcije: {VremeProjekcije}; Cena: {Cena}";
        }
    }
}
