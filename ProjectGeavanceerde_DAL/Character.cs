using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    [Table("Characters")]
    public class Character
    {
        [Key]
        public int CharacterID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }
        [MaxLength(75)]
        public string DevilFruit { get; set; }
        public int? Bounty { get; set; }
        [Required]
        public bool Haki { get; set; } //maybe haki als aparte entity
        [Required]
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int BloodtypeID { get; set; }
        public int SpeciesID { get; set; }

        [ForeignKey("BloodtypeID")]
        public Bloodtype Bloodtype { get; set; }

        [ForeignKey("SpeciesID")]
        public Species Species { get; set; }
        public ICollection<Character_Affiliation> Character_Affiliations { get; set; }
        public ICollection<Character_Arc> Character_arcs { get; set; }
        public ICollection<Character_Place> Character_places { get; set; }
    }
}




