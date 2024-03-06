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
        public String ip { set; get; }

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
                listMembers.ItemsSource = bdd.GetAllPersonnel();
                listFonctions.ItemsSource = bdd.GetAllFonctions();
                listServices.ItemsSource = bdd.GetAllServices();
            }
            catch {

            }
        }
        private void MenuItem_ParamBDD(object sender, RoutedEventArgs e)
        {
            Window1.Instance.Show();
            Window1.Instance.main = this;
        }
        private void listMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listMembers.SelectedItems != null)
            {
                Personnel person = (Personnel)listMembers.SelectedItem;
                textBoxFirstName.Text = person.Prenom;
                textBoxFonction.Text = person.Fonction.Intitule;
                textBoxLastName.Text = person.Nom;
                textBoxPhone.Text = person.Telephone;
                textBoxService.Text = person.Service.Intitule;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Connection_Gestionnaire instance = Connection_Gestionnaire.GetInstance();
            instance.SetBdd(bdd);
            instance.Visibility = Visibility.Visible;
        }
    }
}
