using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Domen
{
    /// <summary>
    /// Represent User class 
    /// </summary>
    public class Korisnik
    {
        /// <value>Represent user id as integer</value>
        public int KorisnikId { get; set; }
        /// <value>Represent user name as string</value>
        public string Ime{ get; set; }
        /// <value>Represent surname as string</value>
        public string Prezime { get; set; }
        /// <value>Represent user gender as enum</value>
        public Pol Pol{ get; set; }
        /// <value>Represent username as string</value>
        public string Username { get; set; }
        /// <value>Represent password as string</value>
        public string  Password { get; set; }
        /// <value>Represent user email as string</value>
        public string Email { get; set; }

    }
    /// <value>Represent gender as enum </value>
    public enum Pol { 
        Muški,
        Ženski,
    }
}
