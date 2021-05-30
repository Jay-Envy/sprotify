using System;
using System.Windows;
using System.Windows.Controls;
using Sprotify_DAL;
using MaterialDesignThemes;
using System.Collections.Generic;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Elementen verbergen tot nummer geselecteerd wordt
            txtGenre.Visibility = Visibility.Hidden;
            txtPlaten.Visibility = Visibility.Hidden;
            txtRegio.Visibility = Visibility.Hidden;
            txtLengte.Visibility = Visibility.Hidden;
            cmbArtiest.Visibility = Visibility.Hidden;

            cmbArtiest.ItemsSource = DatabaseOperations.OphalenArtiesten();
        }



        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            //Is een keuze gemaakt tussen Artiest en Nummer?
            string foutmelding = Valideer("radio");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {

                //Zoja, welke?
                if (rbArtiest.IsChecked == true)
                {
                    //kleine validatie voor artiest
                    //aantalNummers wordt automatisch toegevoegd, verified is bool op zich
                    foutmelding = Valideer("txtNaam");
                    if (string.IsNullOrWhiteSpace(foutmelding))
                    {

                        //Artiest krijgt gegevens (random aantal voor luisteraars)
                        Random random = new Random();
                        Sprotify_DAL.Artiest artiest = new Sprotify_DAL.Artiest
                        {
                            naam = txtNaam.Text,
                            maandelijkseLuisteraars = random.Next(),
                            verified = cbCheckbox.IsChecked == true
                        };

                        //Geldige gegevens?
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
                else if (rbNummer.IsChecked == true)
                {
                    //Validatie voor alle velden buiten checkbox -> sowieso true / false
                    foutmelding = Valideer("radio");
                    foutmelding += Valideer("txtPlaten");
                    foutmelding += Valideer("txtNaam");
                    foutmelding += Valideer("txtLengte");
                    foutmelding += Valideer("txtGenre");
                    foutmelding += Valideer("cmbArtiest");

                    if (string.IsNullOrWhiteSpace(foutmelding))
                    {
                        //Random nummer aangemaakt voor "aantalKeerGespeeld"
                        Random random = new Random();

                        //Nieuw nummer aanmaken
                        Sprotify_DAL.Nummer n = new Sprotify_DAL.Nummer();

                        //Nieuw ArtiestNummer voor connectie met Artiest
                        ArtiestNummer an = new ArtiestNummer();

                        //Nieuwe artiest om geselecteerde item in te stoppen
                        Sprotify_DAL.Artiest a = new Sprotify_DAL.Artiest();
                        a = (Sprotify_DAL.Artiest)cmbArtiest.SelectedItem;

                        //Connectie tussen nummer en artiest
                        an.artiestId = a.id;
                        an.nummerId = n.id;

                        //Nummer krijgt data
                        n.titel = txtNaam.Text;
                        n.lengte = int.Parse(txtLengte.Text);
                        n.aantalKeerGespeeld = random.Next();
                        n.genre = txtGenre.Text;
                        n.platenMaatschappij = txtPlaten.Text;
                        n.like = cbCheckbox.IsChecked ?? false;
                        n.regio = txtRegio.Text;

                        //Check of het nieuwe nummer geldig is
                        if (n.IsGeldig())
                        {
                            int ok = DatabaseOperations.ToevoegenNummer(n);
                            if (ok <= 0)
                            {
                                MessageBox.Show("Toevoegen nummer is niet gelukt");
                            }
                            else
                            {
                                MessageBox.Show($"{n.titel} van {a.naam} is toegevoegd.");
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
            else
            {
                MessageBox.Show(foutmelding);
            }

        }

        //Elementen veranderen naar gelang keuze van de radio
        private void Check_Change(object sender, RoutedEventArgs e)
        {
            if (rbArtiest.IsChecked == true)
            {
                txtGenre.Visibility = Visibility.Hidden;
                txtPlaten.Visibility = Visibility.Hidden;
                txtRegio.Visibility = Visibility.Hidden;
                txtLengte.Visibility = Visibility.Hidden;
                cmbArtiest.Visibility = Visibility.Hidden;
            }
            else if (rbNummer.IsChecked == true)
            {
                txtGenre.Visibility = Visibility.Visible;
                txtPlaten.Visibility = Visibility.Visible;
                txtRegio.Visibility = Visibility.Visible;
                txtLengte.Visibility = Visibility.Visible;
                cmbArtiest.Visibility = Visibility.Visible;
            }
        }

        //VALIDATIE
        private string Valideer(string columnName)
        {
            if (columnName == "radio" && rbArtiest.IsChecked == false && rbNummer.IsChecked == false)
            {
                return "Er moet een item geselecteerd zijn!" + Environment.NewLine;
            }
            else if (columnName == "txtNaam" && string.IsNullOrWhiteSpace(txtNaam.Text))
            {
                return "De naam moet ingevuld zijn!" + Environment.NewLine;
            }
            else if (columnName == "txtPlaten" && string.IsNullOrWhiteSpace(txtPlaten.Text))
            {
                return "De platenmaatschappij moet ingevuld zijn!" + Environment.NewLine;
            }
            else if (columnName == "txtLengte" && !int.TryParse(txtLengte.Text, out int lengte))
            {
                return "De lengte moet een numerieke waarde zijn!" + Environment.NewLine;
            }
            else if (columnName == "txtGenre" && string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                return "Het genre moet ingevuld zijn!" + Environment.NewLine;
            }
            else if (columnName == "cmbArtiest" && cmbArtiest.SelectedItem == null)
            {
                return "Selecteer een artiest!" + Environment.NewLine;
            }
            return "";

        }


    }
}
