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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lackluster
{
    /// <summary>
    /// Interaction logic for WindowLogIn.xaml
    /// </summary>
    public partial class WindowLogIn : Window
    {
        public WindowLogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            //Create instance of Manager window to control objects
            Manager manager = new Manager();

            //Determine if user is Manager or Employee
            //TODO - Implement LDAP Server
            if (txtUser.Text.ToLower() == "admin")
            {
                //Set lblRole to Manager
                manager.lblRole.Content = "MANAGER";

                //Create a LinearGradientBrush to set header colors
                LinearGradientBrush green = new LinearGradientBrush();
                
                //Set GradientStops
                green.GradientStops.Add(new GradientStop(Color.FromArgb(255,26,226,99),0));
                green.GradientStops.Add(new GradientStop(Color.FromArgb(0, 0, 0, 0), 1));

                //Assign gradient to Manager's recHeader
                manager.recHeader.Fill = green;
               
            } else {

                //Set lblRole to Employee
                manager.lblRole.Content = "CLERK";

                //Create a LinearGradientBrush to set header colors
                LinearGradientBrush green = new LinearGradientBrush();

                //Set GradientStops
                green.GradientStops.Add(new GradientStop(Color.FromArgb(255, 26, 99, 226), 0));
                green.GradientStops.Add(new GradientStop(Color.FromArgb(0, 0, 0, 0), 1));

                //Assign gradient to Manager's recHeader
                manager.recHeader.Fill = green;

                //Turn off tab and buttons not appropriate for an Employee
                manager.tbReports.Visibility = Visibility.Hidden;
                manager.tbEmployee.Visibility = Visibility.Hidden;
                manager.btnMovieAdd.Visibility = Visibility.Hidden;
                manager.btnMovieRemove.Visibility = Visibility.Hidden;

            }
            //Open the manager window and close the login window
            manager.Show();
            this.Close();
        }
    }
}
