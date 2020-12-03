using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public class Arc
    {
        [Key]
        public int ArcID { get; set; }
        public string Name { get; set; }
        public int startingchapter { get; set; }
        public int Endingchapter { get; set; } // null allowed
    }
}
