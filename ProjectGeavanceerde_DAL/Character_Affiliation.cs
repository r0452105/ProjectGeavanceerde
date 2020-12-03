using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public class Character_Affiliation
    {
        public int Character_AffiliationID { get; set; }
        public string Name { get; set; }

        public bool current { get; set; } //maybe haki als aparte entity
        public bool leader { get; set; }

        // character reference
        //affiliation reference
    }
}
