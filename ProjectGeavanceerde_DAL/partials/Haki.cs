using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public partial class Haki
    {
        public override bool Equals(object obj)
        {
            return obj is Haki haki &&
                    HakiID == haki.HakiID;
        }
        public override int GetHashCode()
        {
            return -1472635447 + HakiID.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }


    }
}