using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Lackluster
{
    class Customer
    {
        private string customerID;
        private string customerPhoneNumber;
        private string customerFname;
        private string customerLname;
        private string customerEmail;
        private int customerPoints;
        private bool customerActive;

        private bool isCustomer;

        public Customer(string phoneNumber)
        {
            getNewCustomer(phoneNumber);
        }

        private void getNewCustomer(string phoneNumber)
        {
            //Set the database info
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "wildcarddev.cmhc2cqygqpy.us-east-2.rds.amazonaws.com";
            builder.UserID = "master";
            builder.Password = "FrsryVdrBJwn";
            builder.InitialCatalog = "lackluster";

            //Create a connection object using the database info
            MySqlConnection customerConnect = new MySqlConnection(builder.ConnectionString);

            try
            {
                //Connect to the database
                customerConnect.Open();

                //Create a query to search for the movie using the upc code
                string query = "SELECT * FROM customer c WHERE c.phoneNumber = '" + phoneNumber + "';";

                //Create a SQL command
                MySqlCommand cmd = customerConnect.CreateCommand();

                //Set the query to the command's CommandText
                cmd.CommandText = query;

                //Create a reader object and set the executed command
                //this holds the data returned from the database
                var reader = cmd.ExecuteReader();

                //Check if anything was returned
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Set data to public variables
                        this.customerID = reader.GetString(0);
                        this.CustomerPhoneNumber = reader.GetString(1);
                        this.CustomerFname = reader.GetString(2);
                        this.CustomerLname = reader.GetString(3);
                        this.CustomerEmail = reader.GetString(4);
                        this.CustomerPoints = reader.GetInt16(5);
                        this.CustomerActive = reader.GetBoolean(6);

                    }

                    //Set isCustomer to true since we found a customer in the database
                    this.isCustomer = true;
                }
                else
                {
                    //Set isCustomer to false since we did not find a customer in the database
                    this.isCustomer = false;
                }
            }
            catch (Exception e)
            {
                //Print Error
                Console.WriteLine(e.ToString());
                //Set isCustomer to false since we did not find a isCustomer in the database
                this.isCustomer = false;
            }
            finally
            {
                //Close the database connection
                customerConnect.Close();
            }
        }

        public string CustomerID { get => customerID; }
        public string CustomerPhoneNumber { get => customerPhoneNumber; set => customerPhoneNumber = value; }
        public string CustomerFname { get => customerFname; set => customerFname = value; }
        public string CustomerLname { get => customerLname; set => customerLname = value; }
        public string CustomerEmail { get => customerEmail; set => customerEmail = value; }
        public int CustomerPoints { get => customerPoints; set => customerPoints = value; }
        public bool CustomerActive { get => customerActive; set => customerActive = value; }
        public bool IsCustomer { get => isCustomer;  }
        
    }
}
