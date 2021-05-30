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

            dataArtiesten.IsReadOnly = true;
            btnDeleteData.Visibility = Visibility.Hidden;
            btnUpdateData.Visibility = Visibility.Hidden;
            dataArtiesten.ItemsSource = DatabaseOperations.OphalenArtiesten();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {

            MainWindow homeWindow = new MainWindow();
            homeWindow.Show();
            this.Close();
        }

        private void ChangeData_Click(object sender, RoutedEventArgs e)
        {
            if (dataArtiesten.IsReadOnly)
            {
                dataArtiesten.IsReadOnly = false;
                btnDeleteData.Visibility = Visibility.Visible;
                btnUpdateData.Visibility = Visibility.Visible;
            }
            else
            {
                dataArtiesten.IsReadOnly = true;
                btnDeleteData.Visibility = Visibility.Hidden;
                btnUpdateData.Visibility = Visibility.Hidden;
            }

        }

        private void UpdateData_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Artiest");
            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                Sprotify_DAL.Artiest a = dataArtiesten.SelectedItem as Sprotify_DAL.Artiest;
                int ok = DatabaseOperations.AanpassenArtiest(a);
                if (ok > 0)
                {
                    dataArtiesten.ItemsSource = DatabaseOperations.OphalenArtiesten();
                }
                else
                {
                    MessageBox.Show($"{a.naam} aanpassen is mislukt.");

                }
            }
        }

        private void DeleteData_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Artiest");
            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                Sprotify_DAL.Artiest a = dataArtiesten.SelectedItem as Sprotify_DAL.Artiest;
                int ok = DatabaseOperations.VerwijderenArtiest(a);
                if (ok > 0)
                {
                    dataArtiesten.ItemsSource = DatabaseOperations.OphalenArtiesten();
                }
                else
                {
                    MessageBox.Show($"{a.naam} is niet verwijderd.");
                }
            }
            else
            {
                MessageBox.Show(foutmeldingen);
            }
        }

        private void ArtiestToevoegen_Click(object sender, RoutedEventArgs e)
        {
            ArtiestToevoegen artiestToevoegenWindow = new ArtiestToevoegen();
            artiestToevoegenWindow.Show();

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            dataArtiesten.ItemsSource = DatabaseOperations.OphalenArtiesten();
        }


        //VALIDATIE
        private string Valideer(string columnName)
        {
            if (columnName == "Artiest" && dataArtiesten.SelectedItem == null)
            {
                return "Selecteer een artiest!" + Environment.NewLine;
            }
            return "";

        }
    }
}
