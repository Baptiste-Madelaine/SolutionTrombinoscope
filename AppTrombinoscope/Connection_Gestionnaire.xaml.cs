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
        private static Connection_Gestionnaire _instance;
        private ModelBDD _bdd;
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
        
    }
}
