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
        public Collectie(string naam)
        {
            Naam = naam;
        }

        //Methodes
        public abstract string this[string columnName] { get; }



        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Error);
        }
    }
}
