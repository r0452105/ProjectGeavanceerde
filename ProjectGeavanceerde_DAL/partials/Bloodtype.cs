using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public partial class Bloodtype
    {
        public override bool Equals(object obj)
        {
            return obj is Bloodtype bloodtype &&
                    BloodtypeID == bloodtype.BloodtypeID;
        }
        public override int GetHashCode()
        {
            return -1472635447 + BloodtypeID.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }


    }
}