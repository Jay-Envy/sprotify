using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprotify_Models
{
    public class Artiest:Playlist
    {
        //props
        private string regio;
        public string Regio
        {
            get { return regio; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Regio is een verplicht in te vullen veld!");
                }
                regio = value;
            }
        }

        //Constructor
        public Artiest(string naam, string regio):base(naam)
        {
            Naam = naam;
            Regio = regio;
        }

        //Methodes
        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Regio) && string.IsNullOrWhiteSpace(Regio))
                {
                    return "Regio is een verplict in te vullen veld!";
                }
                return base[columnName];
            }

        }
    }
}
