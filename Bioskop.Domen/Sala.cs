using Bioskop.Domen.Validacija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;



namespace Bioskop.Domen
{
    /// <summary>
    /// Represent Hall class
    /// </summary>
    public class Sala
    {
        /// <value>Represent Hall id as int</value>
        public int SalaId { get; set; }
        [Required(ErrorMessage = "Obavezan unos naziva sale")]
        [DisplayName("Naziv sale")]
        /// <value>Represent Hall name as string</value>
        public string NazivSale { get; set; }
        /// <value>Represent list of seats as list of objects Sediste</value>
        public List<Sediste> SedistaUSali { get; set; }
        /// <value>Represent list of films as list of objects Projekcije</value>
        public List<Projekcija> Filmovi { get; set; }
        /// <value>Represent number of rows in hall as int</value>
        [DisplayName("Broj redova")]
        public int BrojRedova { get; set; }
        /// <value>Represent number of columns in hall as int</value>
        [DisplayName("Broj kolona")]
        public int BrojKolona { get; set; }


        /// <returns>Returns basic information of Hall</returns>
        public override string ToString()
        {
            return $"{NazivSale} {BrojRedova} {BrojKolona}";
        }
    }
}
