﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprotify_Models;

namespace Sprotify_DAL
{
    public partial class Artiest: Basisklasse
    {


        public override string this[string columnName]
        {
            get
            {
                if (columnName == "naam" && !string.IsNullOrWhiteSpace(naam))
                {
                    return "Naam mag niet leeg zijn!";
                }
                if (columnName == "maandelijkseLuisteraars" && maandelijkseLuisteraars < 0)
                {
                    return "Maandelijkse luisteraars kunnen niet onder 0!";
                }
                if (columnName == "verified" && verified != true || verified != false)
                {
                    return "Verified moet een booleaans antwoord hebben!";
                }
                return "";
            }
        }
        public override bool Equals(object obj)
        {
            return obj is Artiest artiest &&
                naam == artiest.naam;
        }
    }
}
