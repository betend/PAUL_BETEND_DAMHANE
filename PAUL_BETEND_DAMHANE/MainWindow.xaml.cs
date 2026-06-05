using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace PAUL_BETEND_DAMHANE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public GestionPAUL laGestionPaul { get; set; }
        public MainWindow()
        {
            ChargeData();
            InitializeComponent();
            UCBienvenue uc = new UCBienvenue(this);
            FondEcran.Content = uc;


        }

        public void ChargeData()
        {

            try
            {
                laGestionPaul = new GestionPAUL("Gestion produit");
                this.DataContext = laGestionPaul;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Application.Current.Shutdown();
            }

        }

        public void ConnexionEmploye(string loginTape)
        {
            if (laGestionPaul == null || laGestionPaul.LesEmployes == null)
            {
                MessageBox.Show("Erreur de chargement des employés.");
                return;
            }

            // Recherche de l'employé avec correspondance exacte de colonnes de ta table
            Employe emp = laGestionPaul.LesEmployes.FirstOrDefault(e => string.Equals(e.Employe_login, loginTape, StringComparison.OrdinalIgnoreCase));

            if (emp != null)
            {
                // Vérification du statut selon ta base de données ("vendeur" ou "chef patissier")
                if (string.Equals(emp.Employe_role, "chef patissier", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Bonjour {emp.Employe_login} ! Vous êtes connecté.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    AfficheUCCommandeCP();
                }
                else if (string.Equals(emp.Employe_role, "vendeur", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Bonjour {emp.Employe_login} ! Vous êtes connecté.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    AfficheUCCommandeV();
                }
                else
                {
                    MessageBox.Show("Statut d'employé inconnu.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Identifiant incorrect.", "Échec de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AfficheUCBienvenue()
        {
            UCBienvenue uc = new UCBienvenue(this);
            FondEcran.Content = uc;
        }
        public void AfficheUCAuthentification()
        {
            UCAuthentification uc = new UCAuthentification(this);
            FondEcran.Content = uc;
        }

        public void AfficheUCCatalogueV()
        {
            UCCatalogueV uc = new UCCatalogueV(this);
            FondEcran.Content = uc;
        }
        public void AfficheUCCommandeV()
        {
            UCCommandeV uc = new UCCommandeV(this);
            FondEcran.Content = uc;
        }
        public void AfficheUCPanier()
        {
            UCPanier uc = new UCPanier(this);
            FondEcran.Content = uc;
        }
        public void AfficheUCRechercherClientV()
        {
            UCRechercherClientV uc = new UCRechercherClientV(this);
            FondEcran.Content = uc;
        }
        public void AfficheUCCommandeCP()
        {
            UCCommandeCP uc = new UCCommandeCP(this);
            FondEcran.Content = uc;
        }

        public void AfficheUCCréerCommandeV()
        {
            UCCréerCommandeV uc = new UCCréerCommandeV(this);
            FondEcran.Content = uc;
        }


        public void AfficheUCCréerFicheClientV()
        {
            UCCréerFicheClientV uc = new UCCréerFicheClientV(this);
            FondEcran.Content = uc;
        }
        public void AfficheUCRecapitulatif()
        {
            UCRecapitulatif uc = new UCRecapitulatif(this);
            FondEcran.Content = uc;
        }
        public void AfficheUCDeconnexion()
        {
            UCDeconnexion uc = new UCDeconnexion(this);
            FondEcran.Content = uc;
        }
        public void AfficheUCCatalogueCP()
        {
            UCCatalogueCP uc = new UCCatalogueCP(this);
            FondEcran.Content = uc;
        }
    }
}