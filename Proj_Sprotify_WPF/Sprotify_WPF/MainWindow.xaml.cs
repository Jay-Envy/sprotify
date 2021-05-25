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
            Playlist playlistWindow = new Playlist();
            playlistWindow.Show();
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

        private void AfspeellijstToevoegen_Click(object sender, RoutedEventArgs e)
        {
            PlaylistToevoegen playlistToevoegenWindow = new PlaylistToevoegen();
            Playlist playlistWindow = new Playlist();
            playlistWindow.Show();
            playlistToevoegenWindow.Show();
            this.Close();
        }
    }
}
