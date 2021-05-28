using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprotify_Models;

namespace Sprotify_DAL
{
    public partial class Playlist: Basisklasse
    {

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "naam" && !string.IsNullOrWhiteSpace(naam))
                {
                    return "Naam mag niet leeg zijn!";
                }
                if (columnName == "aantalNummers" && aantalNummers < 0)
                {
                    return "Aantal nummers kan niet onder 0!";
                }
                if (columnName == "private" && @private != true || @private != false)
                {
                    return "Aantal keer gespeeld kan niet onder 0!";
                }
                return "";
            }
        }
    }
}
