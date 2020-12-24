using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public partial class Species
    {
        public override bool Equals(object obj)
        {
            return obj is Species species &&
                    SpeciesID == species.SpeciesID;
        }
        public override int GetHashCode()
        {
            return -1472680747 + SpeciesID.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }


    }
}