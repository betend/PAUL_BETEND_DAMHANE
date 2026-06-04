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
            dgPanier.ItemsSource = gestion.CommandeEnCours.LesLignesCommande;
        }


        private void BtnPlus_Click(object sender, RoutedEventArgs e)

        {

            LigneCommande ligne = ((FrameworkElement)sender).DataContext as LigneCommande;

            if (ligne != null)

            {

                ligne.Quantite++;
                RafraichirVue();

            }

        }

        private void BtnMoins_Click(object sender, RoutedEventArgs e)

        {

            LigneCommande ligne = ((FrameworkElement)sender).DataContext as LigneCommande;

            if (ligne != null)

            {

                if (ligne.Quantite > 1)

                    ligne.Quantite--;
                RafraichirVue();
                if (ligne.Quantite == 1)
                {

                    MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer ce produit du panier ?","Confirmation", MessageBoxButton.YesNo,MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
                        gestion.CommandeEnCours.LesLignesCommande.Remove(ligne);
                    }

          
                }

            }


        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
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


        private void BtnViderPanier_Click(object sender, RoutedEventArgs e)
        {
            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
            
            if (gestion.CommandeEnCours.LesLignesCommande.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Voulez-vous vider tout le panier ?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );
                if (result == MessageBoxResult.Yes)
                {
                    gestion.CommandeEnCours.LesLignesCommande.Clear();
                }
            }
        }
        private void RafraichirVue()
        {
            if (dgPanier?.ItemsSource != null)
            {
                CollectionViewSource.GetDefaultView(dgPanier.ItemsSource).Refresh();
            }
        }



    }
}
