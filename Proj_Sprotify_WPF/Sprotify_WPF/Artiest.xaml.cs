using Sprotify_DAL;
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

namespace Sprotify_WPF
{
    /// <summary>
    /// Interaction logic for Artiest.xaml
    /// </summary>
    public partial class Artiest : Window
    {
        public Artiest()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Verberg informatie
            dataArtiesten.IsReadOnly = true;
            btnDeleteData.Visibility = Visibility.Hidden;
            btnUpdateData.Visibility = Visibility.Hidden;
            txtNaam.Visibility = Visibility.Hidden;
            txtMaand.Visibility = Visibility.Hidden;
            cbVerified.Visibility = Visibility.Hidden;
            //vul datagrid
            dataArtiesten.ItemsSource = DatabaseOperations.OphalenArtiesten();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //ga naar huis
            MainWindow homeWindow = new MainWindow();
            homeWindow.Show();
            this.Close();
        }

        private void ChangeData_Click(object sender, RoutedEventArgs e)
        {
            //verberg/toon extra functionaliteit
            if (btnDeleteData.IsVisible)
            {
                btnDeleteData.Visibility = Visibility.Hidden;
                btnUpdateData.Visibility = Visibility.Hidden;
                txtNaam.Visibility = Visibility.Hidden;
                txtMaand.Visibility = Visibility.Hidden;
                cbVerified.Visibility = Visibility.Hidden;
            }
            else
            {
                btnDeleteData.Visibility = Visibility.Visible;
                btnUpdateData.Visibility = Visibility.Visible;
                txtNaam.Visibility = Visibility.Visible;
                txtMaand.Visibility = Visibility.Visible;
                cbVerified.Visibility = Visibility.Visible;
            }

        }

        private void DataArtiesten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //vul extra functionaliteit op met selectie
            if (dataArtiesten.SelectedItem is Sprotify_DAL.Artiest artiest)
            {
                txtNaam.Text = artiest.naam;
                txtMaand.Text = artiest.maandelijkseLuisteraars.ToString();
                cbVerified.IsChecked = artiest.verified;
            }
        }

        //Update data
        private void UpdateData_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Artiest");
            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                if (dataArtiesten.SelectedItem is Sprotify_DAL.Artiest artiest)
                {
                    //ingevulde tekst wordt assigned
                    artiest.naam = txtNaam.Text;
                    artiest.maandelijkseLuisteraars = int.Parse(txtMaand.Text);
                    // ?? false: bool? is een threestate (true/false/null), in geval van null -> false
                    artiest.verified = cbVerified.IsChecked ?? false;

                    if (artiest.IsGeldig())
                    {
                        int ok = DatabaseOperations.AanpassenArtiest(artiest);
                        if (ok <= 0)
                        {
                            //if no work -> tell me
                            MessageBox.Show($"Artiest {artiest.naam} is niet gewijzigd.");
                        }
                        else
                        {
                            //if work -> show me
                            dataArtiesten.ItemsSource = DatabaseOperations.OphalenArtiesten();
                            Resetten();
                        }
                    }
                    else
                    {
                        MessageBox.Show(artiest.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(foutmeldingen);
            }
        }

        //Verwijder data
        private void DeleteData_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Artiest");
            foutmelding += Valideer("txtNaam");
            foutmelding += Valideer("txtMaand");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                //Komt de selectie overeen met een artiest?
                Sprotify_DAL.Artiest a = dataArtiesten.SelectedItem as Sprotify_DAL.Artiest;
                int ok = DatabaseOperations.VerwijderenArtiest(a);
                if (ok > 0)
                {
                    //I guess so
                    dataArtiesten.ItemsSource = DatabaseOperations.OphalenArtiesten();
                    Resetten();
                }
                else
                {
                    //I guess not
                    MessageBox.Show($"{a.naam} is niet verwijderd.");
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void ArtiestToevoegen_Click(object sender, RoutedEventArgs e)
        {
            //Ik wil nieuwe data toevoegen
            ArtiestToevoegen artiestToevoegenWindow = new ArtiestToevoegen();
            artiestToevoegenWindow.Show();

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            //na toevoegen artiest even refreshen
            dataArtiesten.ItemsSource = DatabaseOperations.OphalenArtiesten();
        }

        //Data resetten
        private void Resetten()
        {
            txtNaam.Text = "";
            txtMaand.Text = "";
            cbVerified.IsChecked = false;
        }

        //VALIDATIE
        private string Valideer(string columnName)
        {
            if (columnName == "Artiest" && dataArtiesten.SelectedItem == null)
            {
                return "Selecteer een artiest!" + Environment.NewLine;
            }
            else if (columnName == "txtNaam" && string.IsNullOrWhiteSpace(txtNaam.Text))
            {
                return "Naam mag niet leeg zijn!" + Environment.NewLine;
            }
            else if (columnName == "txtMaand" && !int.TryParse(txtMaand.Text, out int maand))
            {
                return "Maandelijkse luisteraars moet een numerieke waarde zijn!" + Environment.NewLine;
            }
            return "";

        }
    }
}
