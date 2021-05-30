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
        private TimeSpan span;
        public TimeSpan Span
        {
            get { return span; }
            set
            {
                span = TimeSpan.FromSeconds(lengte);
            }
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "titel" && string.IsNullOrWhiteSpace(titel))
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
                if (columnName == "genre" && string.IsNullOrWhiteSpace(genre))
                {
                    return "Het genre mag niet leeg zijn!";
                }
                if (columnName == "regio" && string.IsNullOrWhiteSpace(regio))
                {
                    return "De regio mag niet leeg zijn!";
                }
                if (columnName == "platenMaatschappij" && string.IsNullOrWhiteSpace(platenMaatschappij))
                {
                    return "De platenmaatschappij mag niet leeg zijn!";
                }
                return "";
            }
        }
        public override bool Equals(object obj)
        {
            return obj is Nummer n &&
                id == n.id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
