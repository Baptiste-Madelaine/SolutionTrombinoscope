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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private static Window1 instance;
        public static Window1 Instance
        {
            get
            {
                if(instance == null || instance.IsVisible == false)
                {
                    instance = new Window1();
                }
                return instance;
            }
        }
        private MainWindow _main;
        public MainWindow main {
            set
            {
                _main = value;
                //ipLab.Text = _main.ip;
                //userLab.Text = _main.user;
                if(_main.port != null)
                {
                    //portLab.Text = _main.port;
                }
            }
            get { return _main; }
             
        }
        
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main.ip = ipLab.Text;
            main.port = portLab.Text;
            main.user = userLab.Text;
            main.pass = passLab.Password;
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
