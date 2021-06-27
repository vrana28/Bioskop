using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Domen
{
    ///<inheritdoc/>
    /// <summary>
    /// Represent class for creating database
    /// </summary>
    /// <remarks>
    /// KorisnikContext inherit DbContext that allows us to use object relations mapper
    ///
    /// <para>Contains DbSet that will create table in database for passed type</para>
    /// </remarks>
    public class KorisnikContext:DbContext
    {
        /// <value>Represent Dbset for Korisnik
        /// <para>This will create Korinsik as one table in database</para>
        /// </value>
        public DbSet<Korisnik> Korisnik{ get; set; }
        /// <summary>
        /// This will configure server to the database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Bioskop;");
        }
        /// <summary>
        /// Used for bulding model in database
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().HasData( new Korisnik { KorisnikId=1,Ime="Admin",Prezime="Admin",
            Username="admin",Password="admin",Pol=Pol.Muški});
        }
    }
}
