using Bioskop.Domen;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bioskop.WebApp.Models
{
    public class GoogleCalendarViewModel
    {
        public List<SelectListItem> Filmovi { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Sale { get; set; } = new List<SelectListItem>();
        public Projekcija Projekcija { get; set; }

        
    }
}
