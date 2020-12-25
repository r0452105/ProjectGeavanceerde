using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    [Table("Places")]
    public partial class Place
    {
        [Key]
        public int PlaceID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }
        [MaxLength(75)]
        public string Ruler { get; set; }
        [Required]
        [MaxLength(40)]
        public string Location { get; set; }
        [MaxLength(40)]
        public string Country { get; set; }
        public ICollection<Character_Place> Character_places { get; set; }
        public ICollection<Arc_Place> Arc_places { get; set; }

    }
}
