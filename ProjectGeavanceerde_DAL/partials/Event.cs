using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectGeavanceerde_DAL
{
    public partial class Event : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Omschrijving" && string.IsNullOrWhiteSpace(Omschrijving))
                {
                    return "Omschrijving moet ingevuld zijn";
                }
                return "";
            }
        }
    }
}