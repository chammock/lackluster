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
        //Initialize total amount to zero
        double total = 0.00;

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

        private void btnStartRental_Click(object sender, RoutedEventArgs e)
        {
            //Show the txtScanEntry Box
            txtScanEntry.Visibility = Visibility.Visible;

            //Set focus to the txtScanEntry Box
            txtScanEntry.Focus();
        }

        private void txtScanEntry_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Look for the Return key press
            if (e.Key == Key.Return)
            {
                //Variable to hold whether movie is already in the list
                bool found = false;

                //Search each list entry
                foreach (Movie i in lstRent.Items)
                {
                    //Determine if the upc entered is already in the list
                    if (i.upc.ToString().Equals(txtScanEntry.Text))
                    {
                        //Set found to true since the movie is already in the list
                        found = true;
                    }
                }

                //Check if the movie is already in the list
                if (found)
                {
                    MessageBox.Show("Movie already added");
                }
                else
                {

                    //Create a movie object by passing the scanned text
                    Movie scannedEntry = new Movie(txtScanEntry.Text);

                    //Check if the movie is actually a movie in our database
                    if (scannedEntry.isMovieCheck())
                    {
                        //Add the movie object to the list
                        lstRent.Items.Add(scannedEntry);

                        //Increase the total
                        total = total + Convert.ToDouble(scannedEntry.moviePrice);
                    } else
                    {
                        MessageBox.Show("This is not an active movie");
                    }

                    //Set the txtTotal box to the total
                    txtTotal.Text = String.Format("{0:C}", total);
                }

                //Reset the txtScanEntry box
                txtScanEntry.Text = "";
            }

            //TODO - Calculate Total cost
        }

        private void btnCompleteRental_Click(object sender, RoutedEventArgs e)
        {
            //Hide the txtScanEntry Box
            txtScanEntry.Visibility = Visibility.Hidden;

            //TODO - Complete the Rental Process
        }
    }
}

