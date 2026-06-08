using PAUL_DAMHANE_BETEND;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Logique d'interaction pour UCCréerFicheClientV.xaml
    /// </summary>
    public partial class UCCréerFicheClientV : UserControl
    {

        private Client UnClient = new Client();
        private MainWindow _mainWindow;

        public UCCréerFicheClientV(MainWindow mainWindow)
        {
            InitializeComponent();
            
            this._mainWindow = mainWindow;
            DataContext = UnClient;
        }

        private void butOngletCommandes_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCCommandeV();
        }

        private void butOngletPanier_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCPanier();
        }

        private void butOngletCatalogue_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCCatalogueV();
        }




        private void butLogOut_Click(Object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _mainWindow.AfficheUCDeconnexion();
            }
        }

        private void butCreerClient_Click(Object sender, RoutedEventArgs e)
        {
       

            try
            {
                UnClient.Client_id = UnClient.Create();
                var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
                gestion.LesClients.Add(UnClient); // ajout à la liste
                MessageBox.Show("Client créé avec succès.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }

            _mainWindow.AfficheUCRechercherClientV();
        }
    }

}
