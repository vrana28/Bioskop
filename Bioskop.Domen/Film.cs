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
        private int FilmId { get; set; }
        [Required]
        [FilmName(ErrorMessage = "Mora da ima minimun 3 karaktera")]
        /// <value>Represent Film name as string</value>
        ///<exception cref="NullReferenceException">Throws when naziv of film is null or empty</exception>
        private string naziv;
        public string Naziv {
            get { return naziv; }
            set { if (string.IsNullOrEmpty(value)) throw new NullReferenceException("Naziv ima null vrednost.");
                naziv = value;
            }
        }

        /// <value>Represent Film director name as string</value>
        ///<exception cref="NullReferenceException">Throws when reziser is null or empty</exception>
        private string reziser;
        public String Reziser {
            get { return reziser; }
            set { if (string.IsNullOrEmpty(value)) throw new NullReferenceException("Reziser ima null vrednost.");
                reziser = value;
            }
        }

        /// <value>Represent Film type as enum Zanr</value>
        ///<exception cref="NullReferenceException">Throws when zanr is null or empty</exception>
        private Zanr zanr;
        public Zanr Zanr
        {
            get { return zanr; }
            set {if(!Enum.IsDefined(typeof(Zanr), value)) throw new NullReferenceException("Zanr ima null vrednost.");
                zanr = value;
            }
        }

        /// <value>Represent Film duration as int</value>
        ///<exception cref="ArgumentOutOfRangeException">Throws when trajanje is null or empty</exception>
        private int trajanje;
        public int Trajanje {
            get { return trajanje; }
            set { if (value < 0) throw new ArgumentOutOfRangeException("Trajanje filma ne moze biti negativno");
                trajanje = value;
            }
        }
        /// <value>Represent Film year of production as int</value>
        ///<exception cref="ArgumentOutOfRangeException">Throws when godina is null or empty</exception>
        private int godina;
        public int Godina {
            get { return godina; }
            set { if (value < 1900) throw new ArgumentOutOfRangeException("Godina filma ne moze biti manja od 1900-te godine.");
                trajanje = godina;                    }
        }
        /// <value>Represent Film poster as string</value>
        /// <exception cref="ArgumentOutOfRangeException">Throws when putanja postera is null or empty</exception>
        private string putanjaPostera;
        [DisplayName("Upload poster")]
        public string PutanjaPostera {
            get { return putanjaPostera; }
            set { if (string.IsNullOrEmpty(value)) throw new NullReferenceException("Putanja postera ima null vrednost.");
                putanjaPostera = value;
            }
        }
        /// <value>Represent Film back poster as string</value>
        /// <exception cref="NullReferenceException">Throws when putanja postera is null or empty</exception>
        private string putanjaBackPostera;
        [DisplayName("Upload back-poster")]
        public string PutanjaBackPostera {
            get {return putanjaBackPostera; }
            set {if(string.IsNullOrEmpty(value)) throw new NullReferenceException("Putanja back postera je null");
                putanjaBackPostera = value;
            }
        }
        /// <value>Represent Film description as string</value>
        /// <exception cref="NullReferenceException">Throws when opis filma is null or empty</exception>
        private string opisFIlma;
        [DisplayName("Opis filma")]
        public string OpisFilma {
            get {   return opisFIlma; }
            set {   if(string.IsNullOrEmpty(value)) throw new NullReferenceException("Opis filma ima null vrednost");
                opisFIlma = value; }
        }
        /// <value>Represent Film link to trailer as string</value>
        /// <exception cref="NullReferenceException">Throws when youtube trailer is null or empty</exception>
        /// 
        private string youtubeTrailer;
        [DisplayName("Youtube trailer:")]
        public string YoutubeTrailer {
            get { return youtubeTrailer; }
            set { if(string.IsNullOrEmpty(value));
                youtubeTrailer = value;
            }
        }
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
