using BddpersonnelContext;
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
    /// Logique d'interaction pour GestionServicessView.xaml
    /// </summary>
    public partial class GestionServicessView : Window
    {
        private static GestionServicessView _instance;
        private ModelBDD _bdd;
        public static GestionServicessView instance
        {
            get
            {
                if (_instance == null || _instance.IsVisible == false)
                {
                    _instance = new GestionServicessView();
                }
                return _instance;
            }
        }
        public ModelBDD bdd
        {
            set
            {
                _bdd = value;
            }
        }
        public GestionServicessView()
        {
            InitializeComponent();
        }
        public void setup()
        {
            try
            {
                dgUsers.ItemsSource = _bdd.GetAllServices();
            }
            catch
            {

            }
        }
        public void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgUsers.SelectedItems != null)
            {
                Service service = (Service) dgUsers.SelectedItem;
                intitule.Text = service.Intitule;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(dgUsers.SelectedItems != null)
            {
                _bdd.DeleteService((Service)dgUsers.SelectedItem);
            }
            dgUsers.ItemsSource = _bdd.GetAllServices();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItems != null)
            {
                _bdd.UpdateService((Service)dgUsers.SelectedItem);
            }
            dgUsers.ItemsSource = _bdd.GetAllServices();
        }
    }
}
