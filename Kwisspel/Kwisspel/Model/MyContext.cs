using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.Model
{
    class MyContext: DbContext
    {

        public DbSet<Vraag> Vragen {
            get { return Vragen; }
            set { Vragen = value; }
        }
    }
}
