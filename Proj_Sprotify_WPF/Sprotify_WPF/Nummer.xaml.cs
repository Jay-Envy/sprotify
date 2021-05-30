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
            dataSearch.ItemsSource = DatabaseOperations.OphalenArtiestNummer();
            btnUpdateData.Visibility = Visibility.Hidden;
            btnDeleteData.Visibility = Visibility.Hidden;
            dataSearch.IsReadOnly = true;
        }

        private void NewNummer_Click(object sender, RoutedEventArgs e)
        {
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
                dataSearch.IsReadOnly = false;
                btnDeleteData.Visibility = Visibility.Visible;
                btnUpdateData.Visibility = Visibility.Visible;
            }
            else
            {
                dataSearch.IsReadOnly = true;
                btnDeleteData.Visibility = Visibility.Hidden;
                btnUpdateData.Visibility = Visibility.Hidden;
            }

        }

        private void UpdateData_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Nummer");
            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                Sprotify_DAL.Nummer nummer = dataSearch.SelectedItem as Sprotify_DAL.Nummer;
                int ok = DatabaseOperations.AanpassenNummer(nummer);
                if (ok > 0)
                {
                    dataSearch.ItemsSource = DatabaseOperations.OphalenArtiestNummer();
                }
                else
                {
                    MessageBox.Show($"{nummer.titel} aanpassen is mislukt.");
                    
                }
            }
        }

        private void DeleteData_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Nummer");
            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                Sprotify_DAL.Nummer nummer = dataSearch.SelectedItem as Sprotify_DAL.Nummer;
                int ok = DatabaseOperations.VerwijderenNummer(nummer);
                if(ok > 0)
                {
                    dataSearch.ItemsSource = DatabaseOperations.OphalenArtiestNummer();
                }
                else
                {
                    MessageBox.Show($"{nummer.titel} is niet verwijderd.");
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

        //VALIDATIE
        private string Valideer(string columnName)
        {
            if (columnName == "Nummer" && dataSearch.SelectedItem == null)
            {
                return "Selecteer een nummer!" + Environment.NewLine;
            }
            return "";

        }

    }
}
