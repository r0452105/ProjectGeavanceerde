using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    [Table("Characters_Affiliations")]
    public class Character_Affiliation
    {
        [Key]
        public int Character_AffiliationID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }
        [Required]
        public bool Current { get; set; } //maybe haki als aparte entity
        public int AffiliationID { get; set; }
        public int CharacterID { get; set; }
        [Required]
        public bool Leader { get; set; }
        [ForeignKey("CharacterID")]
        public Character Character { get; set; }
        [ForeignKey("AffiliationID")]
        public Affiliation Affiliation { get; set; }
    }
}
