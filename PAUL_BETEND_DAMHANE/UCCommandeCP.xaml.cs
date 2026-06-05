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
                dgCommandeCP.ItemsSource = gestion.LesCommandes;

                // ========================================================
                // CORRECTION 1 : BRANCHER LE FILTRE SUR LA DATAGRID
                // ========================================================
                if (dgCommandeCP.ItemsSource != null)
                {
                    dgCommandeCP.Items.Filter = RechercheMotClefCommande;
                }
            }
        }

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
            // ==========================================
            // 2. CORRECTION RADIOBUTTONS : Filtrer sur Est_prete
            // ==========================================
            bool correspondStatut = true;

            if (rbPretes != null && rbPretes.IsChecked == true)
            {
                // Quand ce bouton est coché, on ne garde que les commandes PRÊTES (true)
                correspondStatut = (uneCommande.Est_prete == true);
            }
            else if (rbPasPretes != null && rbPasPretes.IsChecked == true)
            {
                // Quand ce bouton est coché, on ne garde que les commandes NON PRÊTES (false)
                correspondStatut = (uneCommande.Est_prete == false);
            }

            // ==========================================
            // 3. FILTRE CHECKBOX (Catégories d'événements)
            // ==========================================
            bool correspondCategorie = true;

            // On vérifie d'abord si au moins une CheckBox est cochée
            bool auMoinsUnFiltreActif =
                (chkMariage?.IsChecked == true) || (chkAnniversaire?.IsChecked == true) ||
                (chkBapteme?.IsChecked == true) || (chkNaissance?.IsChecked == true) ||
                (chkReunion?.IsChecked == true) || (chkPotDepart?.IsChecked == true) ||
                (chkPortesOuvertes?.IsChecked == true) || (chkFeteReligieuse?.IsChecked == true) ||
                (chkSeminaire?.IsChecked == true) || (chkBuffetEntreprise?.IsChecked == true);

            // Si au moins une case est cochée, la commande doit correspondre à l'un des choix cochés
            if (auMoinsUnFiltreActif)
            {
                string nomCat = uneCommande.UneCategorie_evenement?.Categorie_evenement_nom;

                // On vérifie si la catégorie de la commande correspond à une CheckBox actuellement cochée
                bool matchMariage = (chkMariage?.IsChecked == true && string.Equals(nomCat, "Mariage", StringComparison.OrdinalIgnoreCase));
                bool matchAnniv = (chkAnniversaire?.IsChecked == true && string.Equals(nomCat, "Anniversaire", StringComparison.OrdinalIgnoreCase));
                bool matchBapteme = (chkBapteme?.IsChecked == true && string.Equals(nomCat, "Baptême", StringComparison.OrdinalIgnoreCase));
                bool matchNaissance = (chkNaissance?.IsChecked == true && string.Equals(nomCat, "Naissance", StringComparison.OrdinalIgnoreCase));
                bool matchReunion = (chkReunion?.IsChecked == true && string.Equals(nomCat, "Réunion", StringComparison.OrdinalIgnoreCase));
                bool matchPot = (chkPotDepart?.IsChecked == true && string.Equals(nomCat, "Pot de départ", StringComparison.OrdinalIgnoreCase));
                bool matchPortes = (chkPortesOuvertes?.IsChecked == true && string.Equals(nomCat, "Portes ouvertes", StringComparison.OrdinalIgnoreCase));
                bool matchFete = (chkFeteReligieuse?.IsChecked == true && string.Equals(nomCat, "Fête religieuse", StringComparison.OrdinalIgnoreCase));
                bool matchSeminaire = (chkSeminaire?.IsChecked == true && string.Equals(nomCat, "Séminaire", StringComparison.OrdinalIgnoreCase));
                bool matchBuffet = (chkBuffetEntreprise?.IsChecked == true && string.Equals(nomCat, "Buffet entreprise", StringComparison.OrdinalIgnoreCase));

                // Si aucun des choix cochés ne correspond à la commande, on ne l'affiche pas
                correspondCategorie = (matchMariage || matchAnniv || matchBapteme || matchNaissance ||
                                       matchReunion || matchPot || matchPortes || matchFete ||
                                       matchSeminaire || matchBuffet);
            }

            // ==========================================
            // 4. FILTRE PAR CALENDRIER (DatePicker)
            // ==========================================
            bool correspondDate = true;

            // On vérifie si une date a été sélectionnée dans le calendrier
            if (dpDateRecherche != null && dpDateRecherche.SelectedDate.HasValue)
            {
                // dpDateRecherche.SelectedDate renvoie un DateTime. On le convertit en DateOnly
                DateOnly dateCalendrier = DateOnly.FromDateTime(dpDateRecherche.SelectedDate.Value);

                // On compare directement avec la date de la commande
                correspondDate = (uneCommande.Date_retrait == dateCalendrier);
            }
            else
            {
                // Si le calendrier est vide (aucune date sélectionnée), on affiche toutes les commandes
                correspondDate = true;
            }

            // La commande s'affiche si TOUS les filtres actifs sont OK
            return correspondTexte && correspondStatut && correspondCategorie && correspondDate;
        }

        //  Gestion de la case à cocher (Validation)
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

        private void checkValiderCommande_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null) return;

            Commande commandeSelectionnee = cb.DataContext as Commande;
            if (commandeSelectionnee == null) return;

            // On met à jour l'état de l'objet
            commandeSelectionnee.Est_recuperee = (cb.IsChecked == true);

            // ========================================================
            // VÉRIFICATION DU RETOUR DE LA BASE DE DONNÉES
            // ========================================================
            int resultat = commandeSelectionnee.Update();

            if (resultat > 0)
            {
                // Optionnel : un petit message de confirmation
            }
            else
            {
                // ALERTE : La base de données n'a pas pris en compte la modification
                MessageBox.Show(
                    "Erreur : La mise à jour en base de données a échoué. Veuillez réessayer.",
                    "Erreur de sauvegarde",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                // Annuler visuellement le cochage/décochage puisque la BDD a échoué
                cb.IsChecked = !cb.IsChecked;
                commandeSelectionnee.Est_recuperee = (cb.IsChecked == true);
            }

            RafraichirVue();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            RafraichirVue();
        }

        private void dpDateRecherche_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RafraichirVue();
        }

        // Gestionnaire d'événement unique pour les boutons radio
        private void RadioFiltre_Checked(object sender, RoutedEventArgs e)
        {
            RafraichirVue();
        }

        private void textMotClefCommande_TextChanged(object sender, TextChangedEventArgs e)
        {
            RafraichirVue();
        }


        // Centralisation du rafraîchissement automatique
        private void RafraichirVue()
        {
            if (dgCommandeCP?.ItemsSource != null)
            {
                CollectionViewSource.GetDefaultView(dgCommandeCP.ItemsSource).Refresh();
            }
        }
    }
}