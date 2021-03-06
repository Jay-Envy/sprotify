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
using Sprotify_DAL;

namespace Sprotify_WPF
{
    /// <summary>
    /// Interaction logic for Nummer.xaml
    /// </summary>
    public partial class Nummer : Window
    {
        public Nummer()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //data opvullen
            dataSearch.ItemsSource = DatabaseOperations.OphalenArtiestNummer();
            //zichtbaar wat zichtbaar mag zijn, datagrid is readonly
            btnUpdateData.Visibility = Visibility.Hidden;
            btnDeleteData.Visibility = Visibility.Hidden;
            //aanpassen verbergen
            txtTitel.Visibility = Visibility.Hidden;
            cmbArtiest.Visibility = Visibility.Hidden;
            txtGenre.Visibility = Visibility.Hidden;
            txtLengte.Visibility = Visibility.Hidden;
            txtRegio.Visibility = Visibility.Hidden;
            txtPlaten.Visibility = Visibility.Hidden;
            dataSearch.IsReadOnly = true;
            cmbArtiest.ItemsSource = DatabaseOperations.OphalenArtiesten();
        }

        private void NewNummer_Click(object sender, RoutedEventArgs e)
        {
            //Nieuwe nummers worden toegevoegd aan de database, maar worden niet getoond
            ArtiestToevoegen artiestToevoegenWindow = new ArtiestToevoegen();
            artiestToevoegenWindow.Show();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void ChangeData_Click(object sender, RoutedEventArgs e)
        {
            if (dataSearch.IsReadOnly)
            {
                btnDeleteData.Visibility = Visibility.Visible;
                btnUpdateData.Visibility = Visibility.Visible;
                txtTitel.Visibility = Visibility.Visible;
                cmbArtiest.Visibility = Visibility.Visible;
                txtGenre.Visibility = Visibility.Visible;
                txtLengte.Visibility = Visibility.Visible;
                txtRegio.Visibility = Visibility.Visible;
                txtPlaten.Visibility = Visibility.Visible;
            }
            else
            {
                btnDeleteData.Visibility = Visibility.Hidden;
                btnUpdateData.Visibility = Visibility.Hidden;
                txtTitel.Visibility = Visibility.Hidden;
                cmbArtiest.Visibility = Visibility.Hidden;
                txtGenre.Visibility = Visibility.Hidden;
                txtLengte.Visibility = Visibility.Hidden;
                txtRegio.Visibility = Visibility.Hidden;
                txtPlaten.Visibility = Visibility.Hidden;
            }

        }


        //De datagrid geeft spijtig genoeg niet de juiste data weer. Ook al worden nummers aangepast / toegevoegd (zie data via SQL object explorer), deze worden niet weergegeven
        private void UpdateData_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Nummer");
            foutmelding += Valideer("txtPlaten");
            foutmelding += Valideer("txtTitel");
            foutmelding += Valideer("txtLengte");
            foutmelding += Valideer("txtGenre");
            foutmelding += Valideer("cmbArtiest");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                if (dataSearch.SelectedItem is Sprotify_DAL.ArtiestNummer an)
                {
                    an.Nummer.titel = txtTitel.Text;
                    an.Nummer.genre = txtGenre.Text;
                    an.Nummer.lengte = int.Parse(txtLengte.Text);
                    an.Nummer.platenMaatschappij = txtPlaten.Text;
                    an.Nummer.regio = txtRegio.Text;

                    if (an.Nummer.IsGeldig())
                    {
                        int ok = DatabaseOperations.AanpassenNummer(an);
                        if (ok <= 0)
                        {
                            MessageBox.Show($"Nummer {an.Nummer.titel} is niet gewijzigd.");
                        }
                        else
                        {
                            dataSearch.ItemsSource = DatabaseOperations.OphalenArtiestNummer();
                            Resetten();
                        }
                    }
                    else
                    {
                        MessageBox.Show(an.Nummer.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void DeleteData_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Nummer");
            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                Sprotify_DAL.ArtiestNummer an = dataSearch.SelectedItem as Sprotify_DAL.ArtiestNummer;
                int ok = DatabaseOperations.VerwijderenNummer(an);
                if(ok > 0)
                {
                    dataSearch.ItemsSource = DatabaseOperations.OphalenArtiestNummer();
                }
                else
                {
                    MessageBox.Show($"{an.Nummer.titel} is niet verwijderd.");
                }
            }
            else
            {
                MessageBox.Show(foutmeldingen);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //Als niets wordt ingevuld, geef alle nummers weer, met een zoekopdracht, zoek specifieke nummers
            string search = txtSearch.Text;

            if (search.Length > 0)
            {
                List<ArtiestNummer> nums = DatabaseOperations.OphalenArtiestNummerViaContains(search);
                if (nums.Count != 0)
                {
                    dataSearch.ItemsSource = nums;
                }
                else
                {
                    MessageBox.Show("Er zijn geen resultaten gevonden dat overeenkomt met uw zoekopdracht " + search);
                }
            }
            else
            {
                List<Sprotify_DAL.ArtiestNummer> nums = DatabaseOperations.OphalenArtiestNummer();
                if (nums.Count != 0)
                {
                    dataSearch.ItemsSource = nums;
                }
                else
                {
                    MessageBox.Show("Er zijn geen resultaten gevonden");
                }
            }
        }

        //Zoek met enter
        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Search_Click(sender, e);
            }
        }

        //Data resetten
        private void Resetten()
        {
            txtGenre.Text = "";
            txtTitel.Text = "";
            txtRegio.Text = "";
            txtPlaten.Text = "";
            txtLengte.Text = "";
            txtSearch.Text = "";
            cmbArtiest.SelectedIndex = -1;
        }

        private void DataSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataSearch.SelectedItem is Sprotify_DAL.ArtiestNummer an)
            {
                txtTitel.Text = an.Nummer.titel;
                txtGenre.Text = an.Nummer.genre;
                txtLengte.Text = an.Nummer.lengte.ToString();
                txtPlaten.Text = an.Nummer.platenMaatschappij;
                txtRegio.Text = an.Nummer.regio;
                //cmbArtiest.IsEnabled = false;
                cmbArtiest.ItemsSource = DatabaseOperations.OphalenArtiesten();
            }
        }

        //VALIDATIE
        private string Valideer(string columnName)
        {
            if (columnName == "Nummer" && dataSearch.SelectedItem == null)
            {
                return "Selecteer een nummer!" + Environment.NewLine;
            }
            else if (columnName == "txtTitel" && string.IsNullOrWhiteSpace(txtTitel.Text))
            {
                return "Titel mag niet leeg zijn!" + Environment.NewLine;
            }
            else if (columnName == "txtGenre" && string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                return "Genre mag niet leeg zijn!" + Environment.NewLine;
            }
            else if (columnName == "txtLengte" && !int.TryParse(txtLengte.Text, out int lengte))
            {
                return "Lengte moet een numerieke waarde zijn!" + Environment.NewLine;
            }
            else if (columnName == "txtPlaten" && string.IsNullOrWhiteSpace(txtPlaten.Text))
            {
                return "Platenmaatschappij mag niet leeg zijn!" + Environment.NewLine;
            }
            else if (columnName == "cmbArtiest" && cmbArtiest.SelectedItem == null)
            {
                return "Selecteer een artiest!" + Environment.NewLine;
            }
            return "";

        }


    }
}
