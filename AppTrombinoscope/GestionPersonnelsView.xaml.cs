using BddpersonnelContext;
using DllbddPersonnels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour GestionPersonnelsView.xaml
    /// </summary>
    public partial class GestionPersonnelsView : Window
    {
        private static GestionPersonnelsView _instance;
        private ModelBDD _bdd;
        public static GestionPersonnelsView instance
        {
            get
            {
                if(_instance == null || _instance.IsVisible == false)
                {
                    _instance = new GestionPersonnelsView();
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

        public GestionPersonnelsView()
        {
            InitializeComponent();
            
        }

        public void setup()
        {
            try
            {
                LVFonction.ItemsSource = _bdd.GetAllFonctions();
                LVService.ItemsSource = _bdd.GetAllServices();
            }
            catch
            {

            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                Service s = (Service)LVService.SelectedItem;
                Fonction f = (Fonction)LVFonction.SelectedItem;
                _bdd.NewPersonnel(LastName.Text, Name.Text, NumTel.Text, s.Id, f.Id);
                this.Visibility = Visibility.Hidden;
            }
            catch
            {

            }
            
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {

        }

        private void Choose_picture(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (opfd.ShowDialog() == true)
            {
                Pdp.Source = new BitmapImage(new Uri(opfd.FileName));
            }
        }

        private void LVService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
            
        }
        private void Check()
        {
            if(LVService.SelectedItem != null && LVFonction.SelectedValue != null)
            {
                SaveButton.IsEnabled = true;
                
            }
            else
            {
                SaveButton.IsEnabled = false;
            }
        }

        private void LVFonction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }
    }
}
