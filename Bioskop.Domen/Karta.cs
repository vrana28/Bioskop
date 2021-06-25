using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Bioskop.Domen
{
    /// <summary>
    /// Represent Ticket class
    /// </summary>
    public class Karta
    {
        /// <value>Represent Ticket id as int</value>
        public int KartaId { get; set; }
        /// <value>Represent user of ticket as Korisnik</value>
        public Korisnik Korisnik{ get; set; }
        /// <value>Represent user id as int</value>
        public int KorisnikId { get; set; }
        /// <value>Represent hall as Object<Projekcija></value>
        public Projekcija Projekcija{ get; set; }
        /// <value>Represent hall id as int</value>
        public int ProjekcijaId{ get; set; }
        /// <value>Represent row/column combination as string</value>
        public string RedKolona{ get; set; }
    }
}
