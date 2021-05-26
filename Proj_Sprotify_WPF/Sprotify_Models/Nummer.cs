using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprotify_Models
{
    public class Nummer:Playlist
    {
        //properties
        private int lengte;
        private string genre;

        public int Lengte
        {
            get { return lengte; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Lengte moet groter zijn dan 0!");
                }
                lengte = value;
            }
        }
        public string Genre
        {
            get { return genre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Genre is een verplicht in te vullen veld!");
                }
                genre = value;
            }
        }

        //constructor
        public Nummer(string naam, int cijfer, string string2):base(naam, cijfer, string2)
        {
            Naam = naam;
            Lengte = cijfer;
            Genre = string2;
        }
        //Methodes
        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Genre) && string.IsNullOrWhiteSpace(Genre))
                {
                    return "Genre is een verplict in te vullen veld!";
                }
                else if (columnName == nameof(Lengte) && Lengte <= 0)
                {
                    return "Lengte moet groter zijn dan 0!";
                }
                return base[columnName];
            }

        }
    }
}
