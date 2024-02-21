using BddpersonnelContext;
using DllbddPersonnels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _ip;
        public String ip
        {
            get { return _ip; }
            set
            {
                if (value != _ip)
                {
                    _ip = value;
                    OnPropertyChanged("Name2");
                }
            }
        }
        public String port { set; get; }
        public String user { set; get; }
        public String pass { set; get; }

        private ModelBDD bdd;
        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

        

        private void MenuItem_Connexion(object sender, RoutedEventArgs e)
        {
            bdd = new ModelBDD(user, pass, ip, port);
            try
            {
                List<Personnel> list = bdd.GetAllPersonnel();
                nameUser.Text = list[0].Nom;
                firstNameUser.Text = list[0].Prenom;
            }
            catch {
                Window1 test = new Window1(this);
                test.Show();
            }
        }

        private void MenuItem_ParamBDD(object sender, RoutedEventArgs e)
        {
            Window1 test = new Window1(this);
            test.Show();
        }

        private void nameUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
