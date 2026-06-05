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
    /// <summary>
    /// Logique d'interaction pour FormDetailProduitCP.xaml
    /// </summary>
    public partial class FormDetailProduitCP : Window
    {
        private Produit _produitAModifier;

        public FormDetailProduitCP(Produit produitChoisi)
        {
            InitializeComponent();

            this._produitAModifier = produitChoisi;

            // Liaison des données avec l'IHM
            this.DataContext = this._produitAModifier;
        }

        private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Sécurité élémentaire sur les valeurs saisies
                if (_produitAModifier.Prix <= 0 || _produitAModifier.Nb_parts <= 0)
                {
                    MessageBox.Show("Le prix et le nombre de parts doivent être strictement supérieurs à 0.",
                                    "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Appeler la méthode Update sur l'objet Produit (à écrire à l'étape 3)
                int nbLignesAffectees = _produitAModifier.Update();

                if (nbLignesAffectees > 0)
                {
                    MessageBox.Show("Le produit a été modifié avec succès !",
                                    "Sauvegarde réussie", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.DialogResult = true; // Indique un succès à la vue catalogue pour rafraîchir
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La mise à jour en base de données n'a rien modifié.",
                                    "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue lors de l'enregistrement : {ex.Message}",
                                "Erreur BDD", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
    }
