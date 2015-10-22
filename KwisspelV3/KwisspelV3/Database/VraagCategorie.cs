using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace KwisspelV3.Database
{
    [Table("VraagCategorie")]
    public class VraagCategorie
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
