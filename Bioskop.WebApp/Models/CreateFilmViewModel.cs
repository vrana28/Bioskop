using Bioskop.Domen;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bioskop.WebApp.Models
{
    public class CreateFilmViewModel
    {
        public Film Film{ get; set; }
        public List<SelectListItem> Sale{ get; set; }
    }
}
