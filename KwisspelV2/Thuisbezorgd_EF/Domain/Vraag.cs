using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thuisbezorgd_EF.ViewModel;

namespace Thuisbezorgd_EF.Domain
{
    //Model
    [Table("Vraag")]
    public class Vraag
    {
        [Key]
        public int Aantal { get; set; }
        public String Tekst { get; set; }
        

        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }

        public virtual VraagCategorie Categorie { get; set; }

    }
}
