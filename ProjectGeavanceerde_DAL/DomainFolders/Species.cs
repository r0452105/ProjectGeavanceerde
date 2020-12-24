using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjectGeavanceerde_DAL
{
    [Table("Species")]
    public partial class Species
    {
        [Key]
        public int SpeciesID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
