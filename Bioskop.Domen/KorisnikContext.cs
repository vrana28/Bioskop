using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bioskop.Domen
{
    public class KorisnikContext:DbContext
    {
        public DbSet<Korisnik> Korisnik{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Bioskop;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().HasData( new Korisnik { KorisnikId=1,Ime="Admin",Prezime="Admin",
            Username="admin",Password="admin",Pol=Pol.Muški});
        }
    }
}
