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
using static System.Collections.Specialized.BitVector32;

namespace PAUL_BETEND_DAMHANE
{
    /// <summary>
    /// Logique d'interaction pour UCCatalogueV.xaml
    /// </summary>
    public partial class UCCatalogueV : UserControl
    {

        public GestionPAUL laGestionPaul { get; set; }

        private MainWindow _mainWindow;
        public UCCatalogueV(MainWindow mainWindow)
        {

            InitializeComponent();
            _mainWindow = mainWindow;
            dgProduits.Items.Filter = RechercheMotClefProduit;

        }

        private bool RechercheMotClefProduit(object obj)
        {
            if (String.IsNullOrEmpty(txtboxRecherche.Text))
                return true;
            Produit unProduit = obj as Produit;
            return (unProduit.UneRecette.Recette_nom.StartsWith(txtboxRecherche.Text, StringComparison.OrdinalIgnoreCase));
        }

        private void textMotClefProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgProduits.ItemsSource).Refresh();
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
            dgProduits.ItemsSource = gestion.LesProduits;
        }

        private void butLogOut_Click(Object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) {
                _mainWindow.AfficheUCDeconnexion();
            }

        }

        private void butAjouterAuPanier_Click(Object sender, RoutedEventArgs e)
        {
            Produit produitSelectionne = dgProduits.SelectedItem as Produit;

            if (produitSelectionne == null)

            {

                MessageBox.Show("Veuillez sélectionner un produit.");

                return;

            }
            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;

            LigneCommande ligneExistante = gestion.CommandeEnCours.LesLignesCommande.SingleOrDefault(l => l.UnProduit.Produit_id == produitSelectionne.Produit_id);

            if (ligneExistante == null)

            {

                LigneCommande nouvelleLigne = new LigneCommande

                {

                    UnProduit = produitSelectionne,

                    Quantite = 1

                };

                gestion.CommandeEnCours.LesLignesCommande.Add(nouvelleLigne);

            }

            else

            {

                ligneExistante.Quantite++;

            }

        }
    }
}

