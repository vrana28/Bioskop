using Bioskop.Domen.Validacija;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace Bioskop.Domen
{
    /// <summary>
    /// Represent Film class
    /// </summary>
    public class Film : IEntity
    {
        /// <value>Represent Film id as int</value> ssss
        public int FilmId { get; set; }
        [Required]
        [FilmName(ErrorMessage = "Mora da ima minimun 3 karaktera")]
        /// <value>Represent Film name as string</value>
        public string Naziv { get; set; }
        /// <value>Represent Film director name as string</value>
        public String Reziser { get; set; }
        /// <value>Represent Film type as enum Zanr</value>
        public Zanr Zanr { get; set; }
        /// <value>Represent Film duration as int</value>
        public int Trajanje { get; set; }
        /// <value>Represent Film year of production as int</value>
        public int Godina { get; set; }
        /// <value>Represent Film poster as string</value>
        [DisplayName("Upload poster")]
        public string PutanjaPostera { get; set; }
        /// <value>Represent Film back poster as string</value>
        [DisplayName("Upload back-poster")]
        public string PutanjaBackPostera { get; set; }
        /// <value>Represent Film description as string</value>
        [DisplayName("Opis filma")]
        public string OpisFilma { get; set; }
        /// <value>Represent Film link to trailer as string</value>
        [DisplayName("Youtube trailer:")]
        public string YoutubeTrailer { get; set; }
        /// <value>Represent Film hall as list of Object<Projekcija></value>
        public List<Projekcija> Sale{ get; set; }
        /// <returns>Returns information about film  as string</returns>
        public override string ToString()
        {
            return $"{Naziv} {Reziser} {Zanr} {Godina} {Trajanje} {Zanr} ";
        }
    }

    public class Image { 
    
        public byte[] Slika { get; set; }
        public string Extension { get; set; }

    }

    /// <summary>
    /// Represent enum Zanr as type of Film
    /// </summary>
    public enum Zanr { 
    
        Komedija,
        Akcija,
        Animirani,
        Horor,
        SciFi,
        Avantura,
        Drama
    }
}
