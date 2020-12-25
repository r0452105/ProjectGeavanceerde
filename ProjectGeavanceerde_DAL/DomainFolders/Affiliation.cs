using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    [Table("Affiliations")]
    public partial class Affiliation
    {
        [Key]
        public int AffiliationID { get; set; }
        public int FactionID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }
        [ForeignKey("FactionID")]
        public Faction Faction { get; set; }
    }
}
