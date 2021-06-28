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
        /// <exception cref="NullReferenceException">Throws when red is null or empty</exception>
        private char red;
        public char Red {
            get { return red; }
            set { if(char.IsWhiteSpace(value)) throw new NullReferenceException("Red ima null vrednost");
                red = value;
            }
        }
        /// <value>Represent column as int</value>
        /// <exception cref="NullReferenceException">Throws when kolona is negative.</exception>
        private int kolona;
        public int Kolona {
            get {return kolona; }
            set {if(value <=0) throw new ArgumentOutOfRangeException("Red ima negativnu vrednost.");
                kolona = value;
            }
        }
        /// <value>Represent hall as object Hall</value>
        public Sala Sala{ get; set; }
        /// <value>Represent hall id as int</value>
        public int SalaId { get; set; }
        /// <value>Represent free seat as boolean</value>
        /// <exception cref="NullReferenceException">Throws when slobodno sediste is neither false or true.</exception>
        private bool slobodnoSediste;
        public bool SlobodnoSediste{
            get { return slobodnoSediste; }
            set { if(!value.Equals(true) || !value.Equals(false)) throw new ArgumentOutOfRangeException("Slobodno sediste moze da ima true/false vrednost.");
                slobodnoSediste = value;
            }
        }
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
