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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sprotify_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Artiesten_Click(object sender, RoutedEventArgs e)
        {
            Artiest artiestWindow = new Artiest();
            artiestWindow.Show();
            this.Close();
        }

        private void Afspeellijst_Click(object sender, RoutedEventArgs e)
        {
            Nummer nummerWindow = new Nummer();
            nummerWindow.Show();
            this.Close();
        }

        private void ArtiestToevoegen_Click(object sender, RoutedEventArgs e)
        {
            ArtiestToevoegen artiestToevoegenWindow = new ArtiestToevoegen();
            Artiest artiestWindow = new Artiest();
            artiestWindow.Show();
            artiestToevoegenWindow.Show();
            this.Close();
        }

        private void NummerToevoegen_Click(object sender, RoutedEventArgs e)
        {
            NummerToevoegen nummerToevoegenWindow = new NummerToevoegen();
            Nummer nummerWindow = new Nummer();
            nummerWindow.Show();
            nummerToevoegenWindow.Show();
            this.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //Als niets wordt ingevuld, geef alle nummers weer, met een zoekopdracht, zoek specifieke nummers
            string search = txtSearch.Text;

            if (search.Length > 0)
            {
                List<ArtiestNummer> nums = DatabaseOperations.OphalenArtiestNummer(search);
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
                List<Sprotify_DAL.Nummer> nums = DatabaseOperations.OphalenNummers();
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
            if (columnName=="Orderlijn" && dataSearch.SelectedItem == null)
            {
                return "Selecteer een orderlijn!" + Environment.NewLine;
            }
            if (columnName=="txtHoeveelheid" && !int.TryParse("txtHoeveelheid.Text", out int hoeveelheid))
            {
                return "Hoeveelheid moet een numerieke waarde zijn!"; 
            }
            return "";
        }


        //Zoekopdracht nummer komt terug als Nummer - Artiest - Lengte
        //Seconden naar lengte: TimeSpan ts = TimeSpan.FromSeconds(seconden);

    }
}
