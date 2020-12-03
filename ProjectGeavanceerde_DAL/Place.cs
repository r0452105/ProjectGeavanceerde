using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public class Place
    {
        public int PlaceID { get; set; }
        public string Name { get; set; }
        public string Ruler { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }

    }
}
