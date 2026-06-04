using PAUL_DAMHANE_BETEND;
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
    /// Logique d'interaction pour UCCommandeV.xaml
    /// </summary>
    public partial class UCCommandeV : UserControl
    {
        private MainWindow _mainWindow;

        public UCCommandeV(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            dgCommandeV.Items.Filter = RechercheMotClefCommande; 
        }

        // Méthode de filtrage combinée (TextBox + RadioButtons)
        private bool RechercheMotClefCommande(object obj)
        {
            Commande uneCommande = obj as Commande;
            if (uneCommande == null) return false;

            // ==========================================
            // 1. FILTRE TEXTBOX (Nom du Client)
            // ==========================================
            bool correspondTexte = true;
            if (!String.IsNullOrEmpty(txtboxRecherche.Text))
            {
                correspondTexte = uneCommande.UnClient.Nom.StartsWith(txtboxRecherche.Text, StringComparison.OrdinalIgnoreCase); 
            }

            // ==========================================
            // 2. FILTRE RADIOBUTTONS (Statut de récupération)
            // ==========================================
            bool correspondStatut = true;

            // Si le bouton "Récupérées" est coché, on ne garde que les commandes avec est_recuperee == true
            if (rbRecuperees != null && rbRecuperees.IsChecked == true)
            {
                correspondStatut = (uneCommande.Est_recuperee == true);
            }
            // Si le bouton "Non récupérées" est coché, on ne garde que les commandes avec est_recuperee == false
            else if (rbNonRecuperees != null && rbNonRecuperees.IsChecked == true)
            {
                correspondStatut = (uneCommande.Est_recuperee == false);
            }
            // Note : Si "radToutes" est coché, correspondStatut reste à true (on prend tout)

            // La commande est affichée uniquement si elle valide les deux filtres
            return correspondTexte && correspondStatut;
        }

        // Rafraîchissement lors de la saisie de texte
        private void textMotClefCommande_TextChanged(object sender, TextChangedEventArgs e)
        {
            RafraichirVue(); 
        }

        // Méthode unique appelée au clic de N'IMPORTE QUEL RadioButton
        private void RadioFiltre_Checked(object sender, RoutedEventArgs e)
        {
            RafraichirVue();
        }

        // Centralisation du rafraîchissement
        private void RafraichirVue()
        {
            if (dgCommandeV?.ItemsSource != null)
            {
                CollectionViewSource.GetDefaultView(dgCommandeV.ItemsSource).Refresh(); 
            }
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

        private void UserControl_Loaded(Object sender, RoutedEventArgs e)
        {
            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
            dgCommandeV.ItemsSource = gestion.LesCommandes; 
        }

        private void butLogOut_Click(Object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _mainWindow.AfficheUCBienvenue();
            }
        }
    }
}