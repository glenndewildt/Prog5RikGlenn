using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwisspelV3.Database
{
    //Model
    [Table("Vraag")]
    public class Vraag
    {
        [Key]
        public int Id { get; set; }
        public String Tekst { get; set; }

        public int AantalAntwoorden { get; set; }


        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }

        public virtual VraagCategorie Categorie { get; set; }

    }
}
