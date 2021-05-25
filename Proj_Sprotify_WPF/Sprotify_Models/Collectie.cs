using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprotify_Models
{
    public abstract class Collectie
    {
        //properties
        private string naam;
        public string Naam
        {
            get { return naam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Naam is een verplicht in te vullen veld!");
                }
                naam = value;
            }
        }
        public string Foutmeldingen
        {
            get
            {
                string foutmeldingen = "";
                foreach (var item in this.GetType().GetProperties())
                {
                    if (item.CanRead && item.CanWrite)
                    {
                        string fout = Valideer(item.Name);
                        if (!string.IsNullOrWhiteSpace(fout))
                        {
                            foutmeldingen += fout + Environment.NewLine;
                        }
                    }
                }
                return foutmeldingen;
            }
        }

        //constructor
        public Collectie(string naam)
        {
            Naam = naam;
        }

        //Methodes
        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Foutmeldingen);
        }
        public abstract string Valideer(string propertynaam);
    }
}
