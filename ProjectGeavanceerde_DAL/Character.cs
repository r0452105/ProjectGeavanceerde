using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public class Character
    {
            public int CharacterID { get; set; }
            public string Name { get; set; }
            public string DevilFruit { get; set; }
            public int Bounty { get; set; }
            public bool haki { get; set; } //maybe haki als aparte entity
            public bool gender { get; set; }
            public DateTime birthday { get; set; }
            // bloodtype reference
            // species reference
    }
}




