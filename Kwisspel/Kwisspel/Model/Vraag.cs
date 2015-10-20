using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.Model
{
    [Table("Vraag")]
   public  class Vraag
    {
        [Key]
        public int Id { get; set; }

        public string Soort { get; set; }

        public int Antwoord { get; set; }

        public string StringVraag { get; set; }

    }
}
