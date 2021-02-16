using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Urna.Models;

namespace MVC_Urna.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
            // some codes
        }

        public DbSet<Candidatos> Candidatos {get;set;}
       public DbSet<Votacao> Votacao {get;set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            /// optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MVC_API_Urna;Integrated Security=SSPI;");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MVC_API_Urna;Trusted_Connection=True;MultipleActiveResultSets=true");



        }
    }
}
