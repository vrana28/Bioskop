using Bioskop.Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioskop.WebApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password{ get; set; }
        [Required]
        public Pol Pol{ get; set; }
    }
}
