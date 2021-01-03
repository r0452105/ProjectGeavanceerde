using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectGeavanceerde_DAL
{
    public partial class Arc : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Name" && string.IsNullOrWhiteSpace(Name))
                {
                    return "Naam moet ingevuld zijn.";
                }
                if (columnName == "Startingchapter" && Startingchapter <= 0)
                {
                    return "Beginchapter moet hoger dan 0 zijn.";
                }
                if (columnName == "Endingchapter" && Endingchapter <= 0)
                {
                    return "Eindchapter moet hoger dan 0 zijn.";
                }
                return "";
            }
        }
    }
}