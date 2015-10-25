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
    [Table("Antwoord")]
    public class Antwoord
    {
        [Key]
        public int Id { get; set; }
        public String Tekst { get; set; }

        public Boolean GoeieAntwoord { get; set; }


        [ForeignKey("BijVraag")]
        public int BijvraagId { get; set; }

        public virtual Vraag BijVraag { get; set; }

    }
}
