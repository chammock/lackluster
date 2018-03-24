using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Lackluster
{
    public class Movie
    {
        //Variables for the movie object
        public string movieID { get; set; }
        public string movieTitle { get; set; }
        public string movieRating { get; set; }
        public string releaseYear { get; set; }
        public string movieGenre { get; set; }
        public string upc { get; set; }
        public string moviePrice { get; set; }

        private bool isMovie { get; set; }

        public Movie(string upc)
        {
            //Call getNewMovie to search database
            getNewMovie(upc);
            
        }

        private void getNewMovie(string upc)
        {
            //Set the database info
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "wildcarddev.cmhc2cqygqpy.us-east-2.rds.amazonaws.com";
            builder.UserID = "master";
            builder.Password = "FrsryVdrBJwn";
            builder.InitialCatalog = "lackluster";

            //Create a connection object using the database info
            MySqlConnection movieConnect = new MySqlConnection(builder.ConnectionString);
            try
            {
                //Connect to the database
                movieConnect.Open();

                //Create a query to search for the movie using the upc code
                string query = "Select m.movieID, m.movieTitle, m.movieRating, m.releaseYear, m.movieGenre, upc.upc From movies m Inner Join moviesUPC upc on m.movieid = upc.movieId Where upc.upc = '" + upc + "'";

                //Create a SQL command
                MySqlCommand cmd = movieConnect.CreateCommand();

                //Set the query to the command's CommandText
                cmd.CommandText = query;

                //Create a reader object and set the executed command
                //this holds the data returned from the database
                var reader = cmd.ExecuteReader();

                //Check if anything was returned
                if (reader.HasRows)
                {
                    //Move through the results - should only be one
                    while (reader.Read())
                    {
                        //Set data to public variables
                        this.movieID = reader.GetString(0);
                        this.movieTitle = reader.GetString(1);
                        this.movieRating = reader.GetString(2);
                        this.releaseYear = reader.GetString(3);
                        this.movieGenre = reader.GetString(4);
                        this.upc = reader.GetString(5);
                        this.moviePrice = "3.00";

                    }

                    //Set isMovie to true since we found a movie in the database
                    this.isMovie = true;
                }
                else
                {
                    //Set isMovie to false since we did not find a movie in the database
                    this.isMovie = false;
                }

                
            }
            catch (Exception e)
            {
                //Print Error
                Console.WriteLine(e.ToString());
                //Set isMovie to false since we did not find a movie in the database
                this.isMovie = false;
            }
            finally
            {
                //Close the database connection
                movieConnect.Close();
            }
        }

        public bool isMovieCheck()
        {
            //Return isMovie to determine if this is a movie from the database
            return this.isMovie;
        }
    }
}
