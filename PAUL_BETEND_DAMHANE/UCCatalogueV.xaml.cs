using PAUL_DAMHANE_BETEND;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
            if (gestion != null)
            {
                // 1. On donne d'abord les données au DataGrid
                dgProduits.ItemsSource = gestion.LesProduits;

                // 2. On applique le filtre unique ICI, une fois que les données sont bien chargées
                if (dgProduits.Items != null)
                {
                    dgProduits.Items.Filter = RechercheFiltreProduit;
                }
            }
        }

        // ==========================================
        // LE FILTRE GLOBAL UNIQUE
        // ==========================================
        private bool RechercheFiltreProduit(object obj)
        {
            Produit unProduit = obj as Produit;
            if (unProduit == null) return false;

            // ------------------------------------------
            // 1. FILTRE TEXTBOX
            // ------------------------------------------
            bool correspondTexte = true;
            if (!string.IsNullOrEmpty(txtboxRecherche.Text))
            {
                string nomRecette = unProduit.UneRecette?.Recette_nom;
                if (nomRecette != null)
                {
                    correspondTexte = nomRecette.StartsWith(txtboxRecherche.Text, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    correspondTexte = false;
                }
            }

            // ------------------------------------------
            // 2. FILTRE COMBOBOX (Catégorie)
            // ------------------------------------------
            bool correspondCategorie = true;

            if (cboCategorie != null && cboCategorie.SelectedItem != null)
            {
                ComboBoxItem itemSelectionne = cboCategorie.SelectedItem as ComboBoxItem;
                string categorieFiltre = itemSelectionne.Content?.ToString();
                string categorieProduit = unProduit.UneRecette?.UneCategorie?.Categorie_nom;

                if (!string.IsNullOrEmpty(categorieFiltre))
                {
                    // Si l'utilisateur choisit "Toutes", on laisse correspondCategorie à true (on affiche tout)
                    // Sinon, on applique le filtre normalement
                    if (!string.Equals(categorieFiltre, "Toutes", StringComparison.OrdinalIgnoreCase))
                    {
                        correspondCategorie = string.Equals(categorieProduit, categorieFiltre, StringComparison.OrdinalIgnoreCase);
                    }
                }
            }

            // ------------------------------------------
            // 3. FILTRE CHECKBOXES (Allergènes)
            // ------------------------------------------
            bool correspondAllergenes = true;
            string listeAllergenesProduit = unProduit.AllergeneTexte ?? "";

            if (chkFruitsACoque?.IsChecked == true && listeAllergenesProduit.Contains("Fruits à coque", StringComparison.OrdinalIgnoreCase))
                correspondAllergenes = false;

            if (chkGluten?.IsChecked == true && listeAllergenesProduit.Contains("Gluten", StringComparison.OrdinalIgnoreCase))
                correspondAllergenes = false;

            if (chkLait?.IsChecked == true && listeAllergenesProduit.Contains("Lait", StringComparison.OrdinalIgnoreCase))
                correspondAllergenes = false;

            if (chkOeuf?.IsChecked == true && listeAllergenesProduit.Contains("Oeuf", StringComparison.OrdinalIgnoreCase))
                correspondAllergenes = false;

            if (chkSesame?.IsChecked == true && listeAllergenesProduit.Contains("Sesame", StringComparison.OrdinalIgnoreCase))
                correspondAllergenes = false;

            if (chkSoja?.IsChecked == true && listeAllergenesProduit.Contains("Soja", StringComparison.OrdinalIgnoreCase))
                correspondAllergenes = false;

            if (chkSulfites?.IsChecked == true && listeAllergenesProduit.Contains("Sulfites", StringComparison.OrdinalIgnoreCase))
                correspondAllergenes = false;

            return correspondTexte && correspondCategorie && correspondAllergenes;
        }

        // ==========================================
        // DÉCLENCHEURS DES FILTRES
        // ==========================================

        private void textMotClefProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            RafraichirVue();
        }

        private void cboCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RafraichirVue();
        }

        private void Allergene_Click(object sender, RoutedEventArgs e)
        {
            RafraichirVue();
        }

        private void RafraichirVue()
        {
            // Sécurité : on ne rafraîchit que si le DataGrid a des éléments
            if (dgProduits?.ItemsSource != null && dgProduits.Items != null)
            {
                CollectionViewSource.GetDefaultView(dgProduits.ItemsSource).Refresh();
            }
        }

        // ==========================================
        // ACTIONS ET NAVIGATIONS
        // ==========================================

        private void butAjouterAuPanier_Click(object sender, RoutedEventArgs e)
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

        private void butLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _mainWindow.AfficheUCDeconnexion();
            }
        }
    }
}