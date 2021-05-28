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
            dataSearch.ItemsSource = DatabaseOperations.OphalenNummers();
            btnUpdateData.Visibility = Visibility.Hidden;
            btnDeleteData.Visibility = Visibility.Hidden;
            dataSearch.IsReadOnly = true;
        }

        private void NewNummer_Click(object sender, RoutedEventArgs e)
        {
            NummerToevoegen nummerToevoegenWindow = new NummerToevoegen();
            nummerToevoegenWindow.Show();
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

        }

        private void DeleteData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
