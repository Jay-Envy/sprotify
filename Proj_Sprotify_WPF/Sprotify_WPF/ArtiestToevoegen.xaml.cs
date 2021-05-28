using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Sprotify_Models;
using Sprotify_DAL;

namespace Sprotify_WPF
{
    /// <summary>
    /// Interaction logic for ArtiestToevoegen.xaml
    /// </summary>
    public partial class ArtiestToevoegen : Window
    {
        public ArtiestToevoegen()
        {
            InitializeComponent();
        }


        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("txtArtiestNaam");
            foutmelding += Valideer("txtArtiestMaand");
            foutmelding += Valideer("txtArtiestVerified");
            foutmelding += Valideer("txtArtiestFollow");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                

                Sprotify_DAL.Artiest artiest = new Sprotify_DAL.Artiest();
                artiest.naam = txtArtiestNaam.Text;
                artiest.maandelijkseLuisteraars = int.Parse(txtArtiestMaand.Text);
                artiest.verified = bool.Parse(txtArtiestVerified.Text);

                if (artiest.IsGeldig())
                {
                    int ok = DatabaseOperations.ToevoegenArtiest(artiest);
                    if (ok <= 0)
                    {
                        MessageBox.Show("Toevoegen artiest is niet gelukt");
                    }
                    else
                    {
                        MessageBox.Show($"{artiest.naam} is toegevoegd.");
                    }
                }
                {

                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }
        
        //VALIDATIE
        private string Valideer(string columnName)
        {
            if (columnName == "txtArtiestNaam" && string.IsNullOrWhiteSpace(txtArtiestNaam.Text))
            {
                return "De naam moet ingevuld zijn!" + Environment.NewLine;
            }
            if (columnName == "txtArtiestMaand" && !int.TryParse(txtArtiestMaand.Text, out int maand))
            {
                return "Maandelijkse luisteraars moet een numerieke waarde zijn!" + Environment.NewLine;
            }
            if (columnName == "txtArtiestVerified" && !bool.TryParse(txtArtiestVerified.Text, out bool verified))
            {
                return "Verified moet \"True\" of \"False\" zijn!" + Environment.NewLine;
            }
            return "";
        }
    }
}
