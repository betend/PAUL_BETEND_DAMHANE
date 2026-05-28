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
    /// Logique d'interaction pour UCBienvenue.xaml
    /// </summary>
    public partial class UCBienvenue : UserControl
    {
        private MainWindow _mainWindow;
        public UCBienvenue(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void butSeConnecter_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCAuthentification();
        }
    }
}
