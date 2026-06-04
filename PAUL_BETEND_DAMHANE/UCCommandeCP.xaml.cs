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
    /// Logique d'interaction pour UCCommandeCP.xaml
    /// </summary>
    public partial class UCCommandeCP : UserControl
    {
        private MainWindow _mainWindow;
        public UCCommandeCP(MainWindow mainWindow)
        {
            InitializeComponent();
            this._mainWindow = mainWindow;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Récupérer le DataContext global depuis la MainWindow
            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;

            if (gestion != null)
            {
                // On donne la liste des commandes à ton DataGrid spécial Pâtissier
                // (Vérifie bien que son x:Name dans ton XAML est "dgCommandeCP")
                dgCommandeCP.ItemsSource = gestion.LesCommandes;
            }
        }

        // 2. GESTION DE LA CASE À COCHER (Validation)
        private void CheckBoxValiderCommande_Click(object sender, RoutedEventArgs e)
        {
            // On récupère la case cliquée
            CheckBox cb = sender as CheckBox;
            if (cb == null) return;

            // On extrait la ligne "Commande" correspondante
            Commande commandeSelectionnee = cb.DataContext as Commande;
            if (commandeSelectionnee == null) return;

            // Action selon si on coche ou on décoche
            if (cb.IsChecked == true)
            {
                

                // Si vous avez une méthode de sauvegarde en BDD, c'est ici :
                commandeSelectionnee.Update();
            }
            else
            {
                commandeSelectionnee.Est_recuperee = false;
                commandeSelectionnee.Update();
            }
        }
        private void butLogOut_Click(Object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _mainWindow.AfficheUCDeconnexion();
            }
        }
        private void butOngletCommandes_Click(Object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCCommandeCP();
        }
    }

}
