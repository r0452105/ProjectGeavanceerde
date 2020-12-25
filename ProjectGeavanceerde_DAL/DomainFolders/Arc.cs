using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    [Table("Arcs")]
    public partial class Arc
    {
        [Key]
        public int ArcID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }
        [Required]
        public int Startingchapter { get; set; }
        public int? Endingchapter { get; set; }
        public ICollection<Arc_Place> Arc_places { get; set; }
        public ICollection<Character_Arc> Character_arcs { get; set; }

    }
}
