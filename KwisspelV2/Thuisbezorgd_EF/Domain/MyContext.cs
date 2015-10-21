using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thuisbezorgd_EF.Domain
{
    public class MyContext : DbContext
    {
        public DbSet<Vraag> Vragen { get; set; }

        public DbSet<Antwoord> Antwoorden { get; set; }
        public DbSet<VraagCategorie> VraagCategorie { get; set; }
    }
}
