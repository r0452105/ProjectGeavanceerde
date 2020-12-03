using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    [Table("Characters_Places")]
    public class Character_Place
    {
        [Key]
        public int Character_PlaceID { get; set; }
        [ForeignKey("CharacterID")]
        public Character Character { get; set; }
        [ForeignKey("PlaceID")]
        public Place Place { get; set; }
    }
}
