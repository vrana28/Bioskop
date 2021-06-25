using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bioskop.Domen
{
    /// <summary>
    /// Represent Seat class
    /// </summary>
    public class Sediste
    {
        /// <values>Represent id of seat</values>
        public int SedisteId { get; set; }
        /// <value>Represent row as int</value>
        public char Red { get; set; }
        /// <value>Represent column as int</value>
        public int Kolona { get; set; }
        /// <value>Represent hall as object Hall</value>
        public Sala Sala{ get; set; }
        /// <value>Represent hall id as int</value>
        public int SalaId { get; set; }
        /// <value>Represent free seat as boolean</value>
        public bool SlobodnoSediste{ get; set; }
        /// <value>Represent Projection id as int</value>
        public int ProjekcijaId { get; set; }
        /// <value>Represent projection as object Projection</value>
        public Projekcija Projekcija { get; set; }
        /// <returns>Returns information of seat</returns>
        public override string ToString()
        {
            return $"Red: {Red} Mesto:{Kolona}";
        }
    }
}
