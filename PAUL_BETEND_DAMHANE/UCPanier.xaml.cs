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

namespace PAUL_BETEND_DAMHANE
{
    /// <summary>
    /// Logique d'interaction pour UCPanier.xaml
    /// </summary>
    public partial class UCPanier : UserControl
    {
        private MainWindow _mainWindow;
        public UCPanier(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }
        private void butOngletCommandes_Click(Object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCCommandeV();
        }

        private void butOngletPanier_Click(Object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCPanier();
        }

        private void butOngletCatalogue_Click(Object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCCatalogueV();
        }

        private void butSuivant_Click(Object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCRechercherClientV();
        }


        private void butLogOut_Click(Object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _mainWindow.AfficheUCBienvenue();
            }

        }

        private void UserControl_Loaded(Object sender, RoutedEventArgs e)
        {
            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
            dgLignes.ItemsSource = gestion.CommandeEnCours.LesLignesCommande;
        }

    }
}
