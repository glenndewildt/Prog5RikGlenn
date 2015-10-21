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
    [Table("Antwoord")]
    public class Antwoord
    {
        [Key]
        public String Id { get; set; }
        public String Tekst { get; set; }
        


    }
}
