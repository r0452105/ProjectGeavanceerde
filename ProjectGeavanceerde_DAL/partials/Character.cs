﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGeavanceerde_DAL
{
    public partial class Character : Basisklasse
    {
        public override string this[string columnName]
    {
        get
        {
            if (columnName == "CharacterID" && CharacterID <= 0)
            {
                return "CharacterID moet een positief getal zijn!";
            }
            if (columnName == "Bounty" && Bounty <= 0)
            {
                return "Hoeveelheid moet een positief getal zijn!";
            }
            if (columnName == "Name" && string.IsNullOrWhiteSpace(Name))       
            {
                return "Naam moet ingevuld zijn";
            }
            if (columnName =="SpeciesID" && SpeciesID <= 0)
            {
                    return "SpeciesID moet een positief getal zijn!";
            }
            return "";
        }
    }
}
}