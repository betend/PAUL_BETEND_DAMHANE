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
    /// Logique d'interaction pour UCAuthentification.xaml
    /// </summary>
    public partial class UCAuthentification : UserControl
    {
        private MainWindow _mainWindow;
        public event EventHandler LoginReussi;
        public UCAuthentification(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        //private void butConnexion_Click(object sender, RoutedEventArgs e)
        //{
        //    string loginTape = txtboxLogin.Text.Trim();

        //    // À partir de cette ligne, le code sait que "loginTape" existe
        //    if (string.IsNullOrEmpty(loginTape))

        //    //if (txtboxLogin.Text == "damhane" && txtboxPassword.Password == "1234")
        //    //{
        //    //    LoginReussi?.Invoke(this, EventArgs.Empty);
        //    //_mainWindow.AfficheUCCatalogueV();
        //    //}
        //    //else
        //    //    MessageBox.Show("Identifiants incorrects.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

        //}

        private void butConnexion_Click(object sender, RoutedEventArgs e)
        {
            // On récupère le texte écrit dans la TextBox du Login de ton écran
            // Remplace 'txtboxLogin' par le x:Name exact de ta TextBox de saisie
            string login = txtboxLogin.Text.Trim();

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Veuillez saisir votre identifiant.", "Saisie obligatoire", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // On passe le relais à la MainWindow qui stocke la liste globale des employés
            _mainWindow.ConnexionEmploye(login);
        }
    }
}
