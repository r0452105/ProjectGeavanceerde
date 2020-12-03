using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public class Bloodtype
    {
        [Key]
        public int BloodtypeID { get; set; }
        public string Name { get; set; }
    }
}
