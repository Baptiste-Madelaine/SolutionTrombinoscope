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
        private MainWindow main;
        
        public Window1(MainWindow main)
        {
            InitializeComponent();
            this.main = main;

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
