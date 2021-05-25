using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprotify_Models
{
    public class Playlist:Collectie
    {
        //props
        private List<Nummer> nummers;
        public List<Nummer> Nummers { get; set; }

        //Constructor
        public Playlist(string naam) : base(naam)
        {
            Naam = naam;
        }

        //Methodes
        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Naam) && string.IsNullOrWhiteSpace(Naam))
                {
                    return "Naam is een verplicht in te vullen veld!";
                }
                return "";
            }

        }
    }
}
