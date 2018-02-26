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

namespace Lackluster
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        public Manager()
        {
            InitializeComponent();
            //Test Here
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            //Create instance of Manager window to control objects
            WindowLogIn login = new WindowLogIn();

            //Open the login window and close the manager window
            login.Show();
            this.Close();
        }

        private void btnReturnScan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtTest_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Worked");
        }


    }
}
