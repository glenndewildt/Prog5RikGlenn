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
    [Table("Quiz")]
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public String Tekst { get; set; }

        public List<Vraag> Vragen { get; set; }
       


    }
}
