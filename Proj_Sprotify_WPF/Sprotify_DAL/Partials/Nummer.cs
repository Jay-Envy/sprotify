using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprotify_Models;

namespace Sprotify_DAL
{
    public partial class Nummer:Basisklasse
    {
        public override string ToString()
        {
            return this.titel;
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "titel" && !string.IsNullOrWhiteSpace(titel))
                {
                    return "Titel mag niet leeg zijn!";
                }
                if (columnName == "lengte" && lengte < 0)
                {
                    return "Lengte kan niet onder 0!";
                }
                if (columnName == "aantalKeerGespeeld" && aantalKeerGespeeld < 0)
                {
                    return "Aantal keer gespeeld kan niet onder 0!";
                }
                return "";
            }
        }
    }
}
