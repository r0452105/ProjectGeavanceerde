using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    class OnePieceEntities : DbContext
    {
        public OnePieceEntities() : base("OnePieceDB")
        {   

        }
        public DbSet<Character> Characters { get; set; }
    }
}
