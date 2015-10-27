using KwisspelV3.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwisspelV3
{
    public class MyContext : DbContext
    {
        public MyContext(): base("name=MyContext")
        {

        }

        public DbSet<Vraag> Vragen { get; set; }

        public DbSet<Antwoord> Antwoorden { get; set; }
        public DbSet<VraagCategorie> VraagCategorie { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
    }
}
