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
    public partial class Character
    {
        [Key]
        public int CharacterID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }
        [MaxLength(75)]
        public string DevilFruit { get; set; }
        private string _DevilFruitText;
        public string DevilFruitText
        {
            get
            {
                return _DevilFruitText;
            }
            set
            {
                if (DevilFruit == null)
                {
                    _DevilFruitText = "Geen";
                }
                else
                {
                    _DevilFruitText = DevilFruit;
                }
            }
        }
        public decimal? Bounty { get; set; }

        public DateTime Birthday { get; set; }
        public int BloodtypeID { get; set; }
        public int SpeciesID { get; set; }
        public int HakiID { get; set; }
        public int GenderID { get; set; }

        [ForeignKey("HakiID")]
        public Haki Haki { get; set; }

        [ForeignKey("GenderID")]
        public Gender Gender { get; set; }

        [ForeignKey("BloodtypeID")]
        public Bloodtype Bloodtype { get; set; }

        [ForeignKey("SpeciesID")]
        public Species Species { get; set; }

        public ICollection<Character_Affiliation> Character_Affiliations { get; set; }
        public ICollection<Character_Arc> Character_arcs { get; set; }
        public ICollection<Character_Place> Character_places { get; set; }
    }
}



