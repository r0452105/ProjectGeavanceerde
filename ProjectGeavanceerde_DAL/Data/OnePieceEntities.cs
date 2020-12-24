using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public class OnePieceEntities : DbContext
    {
        public OnePieceEntities() : base("OnePieceDB")
        {

        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Affiliation> Affiliations { get; set; }
        public DbSet<Arc> Arcs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Place> Places{ get; set; }
        public DbSet<Species> Soorten { get; set; }
        public DbSet<Bloodtype> Bloodtypes { get; set; }
        public DbSet<Faction> Factions { get; set; }
    }
}