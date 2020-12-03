using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public class Character_Place
    {
        [Key]
        public int Character_PlaceID { get; set; }

        // character reference
        // place reference
    }
}
