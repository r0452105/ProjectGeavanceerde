using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public class Faction
    {
        [Key]
        public int FactionID { get; set; }
        public string Name { get; set; }
    }
}
