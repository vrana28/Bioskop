using EShop.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bioskop.Domen
{
    /// <summary>
    /// Represent User class 
    /// </summary>
    public class Korisnik
    {
        /// <value>Represent user id as integer</value>
        public int KorisnikId { get; set; }
        /// <value>Represent user name as string</value>
        /// <exception cref="NullReferenceException">Throws when ime of korisnik is null or empty</exception>
        private string ime;
        public string Ime{
            get { return ime; }
            set { if(string.IsNullOrEmpty(value)) throw new NullReferenceException("Ime ima null vrednost.");
                ime = value;    }
        }
        /// <value>Represent surname as string</value>
        /// <exception cref="NullReferenceException">Throws when prezime of korisnik is null or empty</exception>
        private string prezime;
        public string Prezime {
            get { return prezime ; }
            set { if(string.IsNullOrEmpty(value)) throw new NullReferenceException("Prezime ima null vrednost");
                prezime = value;    }
        }
        /// <value>Represent user gender as enum</value>
        /// <exception cref="NullReferenceException">Throws when pol of korisnik is null or empty</exception>
        private Pol pol;
        public Pol Pol{
            get { return pol; }
            set { if(!Enum.IsDefined(typeof(Pol),value)) throw new NullReferenceException("Pol ima null vrednost");
                pol = value;
            } 
        }
        /// <value>Represent username as string</value>
        /// <exception cref="NullReferenceException">Throws when username of korisnik is null or empty</exception>
        private string username;
        public string Username {
            get { return username; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new NullReferenceException("Username ima null vrednost");
                username = value;
            }
        }
        /// <value>Represent password as string</value>
        /// <exception cref="NullReferenceException">Throws when password of korisnik is null or empty</exception>
        private string password;
        public string  Password {
            get { return password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullReferenceException("Email cannot be empty or null");
                if (value != "admin")
                {
                    Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{6,})");
                    Match match = regex.Match(value);
                    throw new PasswordException("Wrong password format!");
                    if (!match.Success)
                        password = value;
                }
                password = value;
            }
        }
        /// <value>Represent user email as string</value>
        /// <exception cref="NullReferenceException">Throws when email of korisnik is null or empty</exception>
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullReferenceException("Email cannot be empty or null");
                ///^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$/
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new EmailException("Wrong email format!");

                email = value;
            }
        }

    }
    /// <value>Represent gender as enum </value>
    public enum Pol { 
        Muški,
        Ženski,
    }
}
