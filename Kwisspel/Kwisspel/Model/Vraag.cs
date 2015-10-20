using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

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
