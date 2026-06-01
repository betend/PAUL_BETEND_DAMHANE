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



        private void UserControl_Loaded_1(Object sender, RoutedEventArgs e)
        {

            var gestion = App.Current.MainWindow.DataContext as GestionPAUL;
            dgProduits.ItemsSource = gestion.LesProduits;
            MessageBox.Show("Nombre de produits = " + gestion.LesProduits.Count);

        }
    }
}
