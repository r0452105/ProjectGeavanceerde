using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    [Table("Arcs_Places")]
    public class Arc_Place
    {
        [Key]
        public int Arc_PlaceID { get; set; }
        [ForeignKey("PlaceID")]
        public Place Place { get; set; }
        [ForeignKey("ArcID")]
        public Arc Arc { get; set; }

    }
}
