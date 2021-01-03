using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectGeavanceerde_DAL
{
    public partial class Place : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Name" && string.IsNullOrWhiteSpace(Name))
                {
                    return "Naam moet ingevuld zijn";
                }
                if (columnName == "Location" && string.IsNullOrWhiteSpace(Name))
                {
                    return "Location moet ingevuld zijn";
                }
                return "";
            }
        }
    }
}