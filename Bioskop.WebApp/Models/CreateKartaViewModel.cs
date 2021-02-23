using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bioskop.WebApp.Models
{
    public class CreateKartaViewModel
    {
        public Karta Karta { get; set; }
        public int ProjekcijaId { get; set; }
        public int KorisnikId { get; set; }
        public int BrojKarti { get; set; }


    }
}
