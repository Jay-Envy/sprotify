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
        private int aantalNummers;
        private string beschrijving;
        public int AantalNummers
        {
            get { return aantalNummers; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Het aantal nummers kan niet onder 0!");
                }
                aantalNummers = value;
            }
        }
        public string Beschrijving
        {
            get { return beschrijving; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("De beschrijving mag niet leeg zijn!");
                }
                beschrijving = value;
            }
        }
        public List<Nummer> Nummers { get; set; }



        //Constructor
        public Playlist(string naam, int cijfer, string string2) : base(naam, cijfer, string2)
        {
            Naam = naam;
            AantalNummers = cijfer;
            Beschrijving = string2;
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
                if (columnName == nameof(AantalNummers) && AantalNummers < 0)
                {
                    return "Het aantal nummers kan niet onder 0!";
                }
                if (columnName == nameof(Beschrijving) && string.IsNullOrWhiteSpace(Beschrijving))
                {
                    return "De beschrijving mag niet leeg zijn!";
                }
                return "";
            }

        }
    }
}
