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
    /// Logique d'interaction pour UCRecapitulatif.xaml
    /// </summary>
    public partial class UCRecapitulatif : UserControl
    {

        private MainWindow _mainWindow;
        public UCRecapitulatif(MainWindow mainWindow)
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
            _mainWindow.AfficheUCCréerCommandeV();
        }


        private void butLogOut_Click(Object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _mainWindow.AfficheUCDeconnexion();
            }

        }

        private void UserControl_Loaded(Object sender, RoutedEventArgs e)
        {
            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
            dgRecapitulatif.ItemsSource = gestion.CommandeEnCours.LesLignesCommande;
        }


      
        private void butPlus_Click(object sender, RoutedEventArgs e)

        {

            LigneCommande ligne = ((FrameworkElement)sender).DataContext as LigneCommande;

            if (ligne != null)

            {

                ligne.Quantite++;
                RafraichirVue();

            }

        }

        private void butMoins_Click(object sender, RoutedEventArgs e)

        {

            LigneCommande ligne = ((FrameworkElement)sender).DataContext as LigneCommande;

            if (ligne != null)

            {

                if (ligne.Quantite > 1)

                    ligne.Quantite--;
                RafraichirVue();
                if (ligne.Quantite == 1)
                {

                    MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer ce produit du panier ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
                        gestion.CommandeEnCours.LesLignesCommande.Remove(ligne);
                    }


                }

            }
        }

        private void RafraichirVue()
        {
            if (dgRecapitulatif?.ItemsSource != null)
            {
                CollectionViewSource.GetDefaultView(dgRecapitulatif.ItemsSource).Refresh();
            }
        }        

        private void butSupprimer_Click(object sender, RoutedEventArgs e)
        {
            LigneCommande ligne = ((FrameworkElement)sender).DataContext as LigneCommande;
            if (ligne != null)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Voulez-vous supprimer cette ligne du panier ?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );
                if (result == MessageBoxResult.Yes)
                {
                    var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
                    gestion.CommandeEnCours.LesLignesCommande.Remove(ligne);
                }
            }
        }

        private void butValiderCommande_Click(Object sender, RoutedEventArgs e)
        {
            // 1. On récupère le contexte global de gestion
            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;

            // 2. Sécurité : On vérifie si toutes les lignes ont été supprimées
            if (gestion?.CommandeEnCours?.LesLignesCommande == null || gestion.CommandeEnCours.LesLignesCommande.Count == 0)
            {
                // 3. Si le panier est vide, on affiche le message d'erreur et on bloque
                MessageBox.Show(
                    "Impossible de valider la commande car le panier ne contient plus aucun article !",
                    "Panier vide",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                // 4. On stoppe immédiatement l'exécution de la méthode
                return;
            }

            // 5. Insère ici ton code existant ou futur pour enregistrer la commande en base de données

            try
            {

                int idCommande = gestion.CommandeEnCours.Create();
                gestion.LesCommandes.Add(gestion.CommandeEnCours); // ajout à la liste
                MessageBox.Show("Commande créé avec succès.");


                foreach (LigneCommande uneLigne in gestion.CommandeEnCours.LesLignesCommande)

                {
                    //uneLigne.UnProduit = gestion.LesProduits.SingleOrDefault(produit => produit.Produit_id == uneLigne.Produit_id);
                    
                    uneLigne.Create();

                }
                MessageBox.Show("Le panier a été validé avec succès !");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }



        }
    }
}
