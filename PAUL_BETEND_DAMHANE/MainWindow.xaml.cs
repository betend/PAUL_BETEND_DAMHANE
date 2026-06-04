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

        public void AfficheUCCréerCommandeV()
        {
            UCCréerCommandeV uc = new UCCréerCommandeV(this);
            FondEcran.Content = uc;
        }

    }
}