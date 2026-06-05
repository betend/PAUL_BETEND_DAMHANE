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
    /// Logique d'interaction pour UCCréerCommandeV.xaml
    /// </summary>
    public partial class UCCréerCommandeV : UserControl
    {
        private MainWindow _mainWindow;

        public UCCréerCommandeV(MainWindow mainWindow)
        {
            InitializeComponent();
            this._mainWindow = mainWindow;
        }
        private void butLogOut_Click(Object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _mainWindow.AfficheUCDeconnexion();
            }
        }

        private void butCreerCommande_Click(Object sender, RoutedEventArgs e)
        {
            // 1. Choix de la catégorie de l'événement
            if (cboCategorie == null || cboCategorie.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner la catégorie de l'événement.", "Champ obligatoire", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 2. Date de retrait
            if (dpDateRetrait.SelectedDate == null)
            {
                MessageBox.Show("Veuillez sélectionner la date de retrait.", "Champ obligatoire", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // 3. Date de l'événement
            if (dpDateEvenement.SelectedDate == null)
            {
                MessageBox.Show("Veuillez sélectionner la date de l'événement.", "Champ obligatoire", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            

            // Vérification de cohérence des dates
            DateTime dateEvenement = dpDateEvenement.SelectedDate.Value;
            DateTime dateRetrait = dpDateRetrait.SelectedDate.Value;

            if (dateRetrait < dateEvenement)
            {
                MessageBox.Show("La date de retrait ne peut pas être antérieure à la date de l'événement !", "Incohérence des dates", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // 4. Nombre de personnes (doit être rempli ET être un nombre entier valide)
            if (string.IsNullOrWhiteSpace(txtNbPersonnes.Text))
            {
                MessageBox.Show("Veuillez renseigner le nombre de personnes.", "Champ obligatoire", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtNbPersonnes.Text, out int nbPersonnes) || nbPersonnes <= 0)
            {
                MessageBox.Show("Veuillez saisir un nombre de personnes valide (un entier supérieur à 0).", "Format incorrect", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 5. Si toutes les conditions sont validées, on passe à l'étape suivante
            _mainWindow.AfficheUCRechercherClientV();
        }

    }
}
