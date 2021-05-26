using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprotify_Models
{
    public abstract class Collectie:IDataErrorInfo
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
        private int cijfer;
        public int Cijfer
        {
            get { return cijfer; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Cijfer moet meer dan 0 zijn!");
                }
                cijfer = value;
            }
        }
        private string string2;
        public string String2
        {
            get { return string2; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Naam is een verplicht in te vullen veld!");
                }
                string2 = value;
            }
        }

        public string Error
        {
            get
            {
                string foutmeldingen = "";

                foreach (var property in this.GetType().GetProperties()) //reflection 
                {
                    if (property.CanRead && property.CanWrite)
                    {
                        string fout = this[property.Name];
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
        public Collectie(string naam, int cijfer, string string2)
        {
            Naam = naam;
            Cijfer = cijfer;
            String2 = string2;
        }

        //Methodes
        public abstract string this[string columnName] { get; }



        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Error);
        }
    }
}
