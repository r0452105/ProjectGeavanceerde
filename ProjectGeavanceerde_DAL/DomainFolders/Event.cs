using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    [Table("Events")]
    public partial class Event
    {
        [Key]
        public int EventID { get; set; }
        [Required]
        [MaxLength(2500)]
        public string Omschrijving { get; set; }
        public int Date { get; set; }
        public string EditDate => $"{Date} Years Ago";

    }
}
