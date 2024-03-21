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
    /// Logique d'interaction pour ListePersonnelsView.xaml
    /// </summary>
    public partial class ListePersonnelsView : Window
    {
        private static ListePersonnelsView _instance;
        private ModelBDD _bdd;
        public static ListePersonnelsView instance
        {
            get
            {
                if(_instance == null || _instance.IsVisible == false)
                {
                    _instance = new ListePersonnelsView();
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

        public ListePersonnelsView()
        {
            InitializeComponent();
            
        }

        public void setup()
        {
            try
            {
                listMembers.ItemsSource = _bdd.GetAllPersonnel();
            }
            catch
            {

            }
        }


        private void Cancel(object sender, RoutedEventArgs e)
        {

        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Personnels = _bdd.GetPersonnelByName(LastName.Text);
            Console.WriteLine(Personnels.Count.ToString() + " "+LastName.Text);
            //FirstName.Text = LastName.Text;
            listMembers.ItemsSource = Personnels;
            foreach (Personnel p in Personnels)
            {
                Console.WriteLine(p.Nom);
            }
        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Personnels = _bdd.GetPersonnelByName(FirstName.Text);
            Console.WriteLine(Personnels.Count.ToString() + " " + FirstName.Text);
            //FirstName.Text = LastName.Text;
            listMembers.ItemsSource = Personnels;
            foreach (Personnel p in Personnels)
            {
                Console.WriteLine(p.Prenom);
            }
        }
    }
}
