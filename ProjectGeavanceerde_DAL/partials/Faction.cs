using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public partial class Faction
    {
        public override bool Equals(object obj)
        {
            return obj is Faction faction &&
                    FactionID == faction.FactionID;
        }
        public override int GetHashCode()
        {
            return -1472595447 + FactionID.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }


    }
}