using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwisspelV3.Database
{
    class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            //Seed data zodat je database niet leeg is
            context.Vragen.Add(new Vraag() { Tekst = "Why is Tom Cruise in my closet?"});
            context.SaveChanges();
        }
    }
}
