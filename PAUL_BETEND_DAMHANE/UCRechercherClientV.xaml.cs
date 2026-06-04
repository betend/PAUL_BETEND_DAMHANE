using PAUL_DAMHANE_BETEND;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour UCRechercherClientV.xaml
    /// </summary>
    public partial class UCRechercherClientV : UserControl
    {
        private MainWindow _mainWindow;
        public UCRechercherClientV(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            dgRechercheClient.Items.Filter = RechercheMotClefClient;

        }

        private bool RechercheMotClefClient(object obj)
        {
            if (String.IsNullOrEmpty(txtboxRecherche.Text))
                return true;
            Client unClient = obj as Client;
            return (unClient.Nom.StartsWith(txtboxRecherche.Text, StringComparison.OrdinalIgnoreCase) || unClient.Prenom.StartsWith(txtboxRecherche.Text, StringComparison.OrdinalIgnoreCase) || unClient.Telephone.StartsWith(txtboxRecherche.Text, StringComparison.OrdinalIgnoreCase));
        }

        private void textMotClefClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgRechercheClient.ItemsSource).Refresh();
            VerifierSiAucunClientTrouve();

        }

        private void UserControl_Loaded(Object sender, RoutedEventArgs e)
        {
            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
            dgRechercheClient.ItemsSource = gestion.LesClients;

        }

        private void butLogOut_Click(Object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _mainWindow.AfficheUCDeconnexion();
            }

        }


        private void VerifierSiAucunClientTrouve()
        {
            ICollectionView vue = CollectionViewSource.GetDefaultView(dgRechercheClient.ItemsSource);
            if (vue == null)
            {
                btnCreerClient.Visibility = Visibility.Visible;
                return;
            }
            int nbResultats = vue.Cast<object>().Count();
            if (nbResultats == 0)
                btnCreerClient.Visibility = Visibility.Visible;
            else
                btnCreerClient.Visibility = Visibility.Collapsed;
        }

        private void btnCreerClient_Click(Object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCCréerFicheClientV();
        }

        private void BbutSelectionner_Click(Object sender, RoutedEventArgs e)
        {
            Client clientSelectionne = dgRechercheClient.SelectedItem as Client;
            if (clientSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.","Attention",MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }
            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
            gestion.CommandeEnCours.UnClient = clientSelectionne;

            _mainWindow.AfficheUCRecapitulatif();

        }
    }
}
