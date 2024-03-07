using DllbddPersonnels;
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

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour Connection_Gestionnaire.xaml
    /// </summary>
    public sealed partial class Connection_Gestionnaire : Window
    {
        private Connection_Gestionnaire()
        {
            InitializeComponent();
        }
        public static Connection_Gestionnaire _instance;
        private ModelBDD _bdd;

        private MainWindow _main;
        public MainWindow main
        {
            set
            {
                _main = value;
            }
            get { return _main; }

        }
        public static Connection_Gestionnaire GetInstance()
        {
            if( _instance == null)
            {
                _instance = new Connection_Gestionnaire();
            }
            return _instance;
        }
        public void SetBdd(ModelBDD bdd)
        {
            this._bdd = bdd;
        }

        private void Connexion(object sender, RoutedEventArgs e)
        {
            _main.user = User.Text;
            _main.pass = Password.Text;
            
            try
            {
                _main.MenuItem_Connexion(sender, e);
                _main.lPersonnel.IsEnabled = true;
                _main.GestionFonctions.IsEnabled = true;
                _main.GestionPersonnels.IsEnabled = true;
                _main.GestionServices.IsEnabled = true;
                this.Visibility = Visibility.Hidden;
            }
            catch 
            {
                /* TODO Things to do while not goot credentials */
            }
            
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
