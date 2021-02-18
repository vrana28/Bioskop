using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bioskop.WebApp.Models
{
    public class ProjekcijaViewModel
    {
        public int Num { get; set; }
        public int SalaId { get; set; }
        public string NazivSale { get; set; }
        public bool Slobodna { get; set; }
    }
}
