using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    [Table("Factions")]
    public partial class Faction
    {
        [Key]
        public int FactionID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }
        public ICollection<Affiliation> Affiliations { get; set; }
    }
}
