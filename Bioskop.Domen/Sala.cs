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
        /// <value>Represent Hall name as string</value>
        /// <exception cref="NullReferenceException">Throws when naziv sale is null or empty.</exception>
        private string nazivsale;
        [Required(ErrorMessage = "Obavezan unos naziva sale")]
        public string NazivSale {
            get { return nazivsale; }
            set { if(string.IsNullOrEmpty(value)) throw new NullReferenceException("Naziv sale ima null vrednost.");
                nazivsale = value;
            }
        }
        /// <value>Represent list of seats as list of objects Sediste</value>
        public List<Sediste> SedistaUSali { get; set; }
        /// <value>Represent list of films as list of objects Projekcije</value>
        public List<Projekcija> Filmovi { get; set; }
        /// <value>Represent number of rows in hall as int</value>
        /// <exception cref="ArgumentOutOfRangeException">Throws when broj redova is negative.</exception>
        private int brojRedova;
        [DisplayName("Broj redova")]
        public int BrojRedova {
            get { return brojRedova; }
            set { if(value< 0 ) throw new ArgumentOutOfRangeException("Broj redova ne moze biti negativan.");
                brojRedova = value;
            }
        }
        /// <value>Represent number of columns in hall as int</value>
        /// <exception cref="ArgumentOutOfRangeException">Throws when broj kolona is negative.</exception>
        private int brojKolona;
        [DisplayName("Broj kolona")]
        public int BrojKolona {
            get { return brojKolona; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Broj redova ne moze biti negativan.");
                brojKolona = value;
            }
        }


        /// <returns>Returns basic information of Hall</returns>
        public override string ToString()
        {
            return $"{NazivSale} {BrojRedova} {BrojKolona}";
        }
    }
}
