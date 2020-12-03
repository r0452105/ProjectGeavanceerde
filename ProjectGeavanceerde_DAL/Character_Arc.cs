using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    [Table("Characters_Arcs")]
    public class Character_Arc
    {
        [Key]
        public int Character_ArcID { get; set; }
        [ForeignKey("CharacterID")]
        public Character Character { get; set; }
        [ForeignKey("ArcID")]
        public Arc Arc { get; set; }
    }
}
