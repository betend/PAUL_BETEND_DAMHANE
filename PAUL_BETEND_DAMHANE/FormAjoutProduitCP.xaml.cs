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
using System.Windows.Shapes;

namespace PAUL_BETEND_DAMHANE
{

    public partial class FormAjoutProduitCP : Window
    {
        public FormAjoutProduitCP()
        {
            InitializeComponent();
            ChargerFenetre();
        }

        private void ChargerFenetre()
        {
            // 1. Affichage du login dans le bandeau
            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
            

            // 2. Remplissage du ComboBox avec les recettes existantes
            try
            {
                // Exemple si vous avez une classe Recette :
                // cboRecettes.ItemsSource = new Recette().FindAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des recettes : " + ex.Message);
            }
        }

        //private void btnValider_Click(object sender, RoutedEventArgs e)
        //{
        //    // 1. Vérification des saisies
        //    if (cboRecettes.SelectedItem == null)
        //    {
        //        MessageBox.Show("Veuillez sélectionner une recette.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    decimal prix;
        //    int nbParts;

        //    if (!decimal.TryParse(txtPrix.Text.Replace('.', ','), out prix) || prix <= 0)
        //    {
        //        MessageBox.Show("Veuillez saisir un prix valide supérieur à 0.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    if (!int.TryParse(txtNbParts.Text, out nbParts) || nbParts <= 0)
        //    {
        //        MessageBox.Show("Veuillez saisir un nombre de parts entier supérieur à 0.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    try
        //    {
        //        // 2. Instanciation du nouveau produit
        //        Produit nouveauProduit = new Produit();
        //        nouveauProduit.Prix = prix;
        //        nouveauProduit.Nb_parts = nbParts;
        //        nouveauProduit.Est_indisponible = (chkIndisponible.IsChecked == true);

        //        // Récupération de la recette sélectionnée pour la liaison d'ID
        //        // Recette recetteSelectionnee = cboRecettes.SelectedItem as Recette;
        //        // nouveauProduit.Recette_id = recetteSelectionnee.Recette_id;

        //        // 3. Appel du Create() en Base de données (À ajouter à l'étape 5)
        //        int idGenere = nouveauProduit.Create();

        //        if (idGenere > 0)
        //        {
        //            MessageBox.Show("Le nouveau produit a été intégré avec succès au catalogue !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        //            this.DialogResult = true;
        //            this.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Erreur lors de l'insertion en BDD : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
