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
        private int beginJaar;
        public int BeginJaar
        {
            get { return beginJaar; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Het beginjaar moet groter zijn dan 0!");
                }
                beginJaar = value;
            }
        }

        //Constructor
        public Artiest(string naam, int cijfer, string string2):base(naam, cijfer, string2)
        {
            Naam = naam;
            BeginJaar = cijfer;
            Regio = string2;
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
