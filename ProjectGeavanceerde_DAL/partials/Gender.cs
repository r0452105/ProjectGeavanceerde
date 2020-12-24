using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public partial class Gender
    {
        public override bool Equals(object obj)
        {
            return obj is Gender gender &&
                    GenderID == gender.GenderID;
        }
        public override int GetHashCode()
        {
            return -1472635447 + GenderID.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }


    }
}