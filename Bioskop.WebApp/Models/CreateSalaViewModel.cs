using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bioskop.WebApp.Models
{
    public class CreateSalaViewModel
    {
        public Sala Sala{ get; set; }
        public List<Sediste> Sedista{ get; set; }
    }
}
