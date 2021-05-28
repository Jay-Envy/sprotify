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
        
        //VALIDATIE
        private string Valideer(string columnName)
        {
            //Enkel naam heeft validatie nodig. Checkbox is automatisch true/false
            if (columnName == "txtArtiestNaam" && string.IsNullOrWhiteSpace(txtArtiestNaam.Text))
            {
                return "De naam moet ingevuld zijn!" + Environment.NewLine;
            }
            return "";
        }

        private void ArtiestToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("txtArtiestNaam");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Random random = new Random();

                Sprotify_DAL.Artiest artiest = new Sprotify_DAL.Artiest();
                artiest.naam = txtArtiestNaam.Text;
                artiest.maandelijkseLuisteraars = random.Next();
                artiest.verified = cbVerified.IsChecked;

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
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Deze actie is niet geldig");
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }

        }
    }
}
