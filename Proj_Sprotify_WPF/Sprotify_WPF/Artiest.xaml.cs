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

        private void Home_Click(object sender, RoutedEventArgs e)
        {

            MainWindow homeWindow = new MainWindow();
            homeWindow.Show();
            this.Close();
        }

        private void ArtiestToevoegen_Click(object sender, RoutedEventArgs e)
        {
            ArtiestToevoegen artiestToevoegenWindow = new ArtiestToevoegen();
            artiestToevoegenWindow.Show();

        }
    }
}
