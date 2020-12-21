using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTPRG403_ICTPRG404_ICTPRG410.Data
{

    /// <summary>
    /// Class name - Repository
    /// This calss is to communicate with database and populate People list
    /// Written by: Viyada Tarapornsin
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// Store for the connection string property.
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// The Repository class constructor.
        /// initialise and assign the correct value for the _connectionString field here using ConfigurationManager
        /// </summary>
        public Repository()
        {
            //initialise and assign the correct value for the _connectionString field here using ConfigurationManager. 
            /* Initialise the _connectionString field member in the constructor of the Repository class. 
                 * This logic is to access the value of the connection string declared in the App.config file 
                 * via the static ConnectionStringSettingsCollection ConnectionStrings property of ConfigurationManager */
            _connectionString = ConfigurationManager.ConnectionStrings["ICTPRG403_ICTPRG404_ICTPRG410"].ConnectionString;
        }

        /// <summary>
        /// The ResetDatabase class constructor
        /// </summary>
        public void ResetDatabase()
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string spName = "RESET_DB";
                    // Stored procedure  
                    using (SqlCommand cm = new SqlCommand(spName, con))
                    {
                        cm.CommandType = CommandType.StoredProcedure;

                        // Opening Connection  
                        con.Open();
                        // Executing the SQL stored procedure  
                        result = cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }

        /// <summary>
        /// GetPeople method - to get a list of people from the database
        /// </summary>
        /// <value>
        /// IEnumerable<Person> - a list of people
        /// </value>
        public IEnumerable<Person> GetPeople()
        {
            var people = new List<Person>();
            //add the logic for retrieving all People records from the database and populatinng the list with the retrieved data so it can be returned
            /* This logic is to retrieve all of the existing records and use the retrieved values to populate 
             * and return a collection of Person objects. */

            try
            {
                // SQL query to retieve all records in people table
                string query = "SELECT * FROM people";

                // Establish the conection 
                // Use using statement to ensure that the ADO.NET SqlConnection and SqlCommand objects are correctly disposed
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    // Pass the connection and the query to the SQL command
                    using (SqlCommand cm = new SqlCommand(query, con))
                    {

                        // Open the connection
                        con.Open();

                        // Execute the SQL query to get a dataset of people
                        SqlDataReader dr = cm.ExecuteReader();

                        // Iterate through the dataset and store each row in the people list
                        while (dr.Read())
                        {
                            // Create Person object
                            Person person = new Person();
                            person.Id = Convert.ToInt32(dr["Id"]);
                            person.FirstName = dr["FirstName"].ToString();
                            person.LastName = dr["LastName"].ToString();
                            person.Height = Convert.ToDouble(dr["Height"]);
                            person.Weight = Convert.ToDouble(dr["Weight"]);

                            // Add the person object to the people list
                            people.Add(person);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            
            return people; 
        }

        /// <summary>
        /// InsertPerson method - to insert a person record to the database from Person object
        /// </summary>
        /// <param name="p">A Person object, holds the person's data</param>
        public int InsertPerson(Person p)
        {
            int result = 0;
            //add the logic for inserting a person record in the database and returning the number of rows affected
            //NOTE: ensure all disposable objects are properly disposed and parameters are used for any SQL commands executed

            try
            {
                // SQL query to insert a new record into people table
                string query = "INSERT INTO people (FirstName, LastName, Height, Weight) VALUES (@firstName,@lastName,@height, @weight)";

                // Establish the conection 
                // Use using statement to ensure that the ADO.NET SqlConnection and SqlCommand objects are correctly disposed
                using (SqlConnection con = new SqlConnection(_connectionString))
                {

                    // Pass the connection and the query to the SQL command
                    using (SqlCommand cm = new SqlCommand(query, con))
                    {
                        cm.Parameters.AddWithValue("@firstName", p.FirstName);
                        cm.Parameters.AddWithValue("@lastName", p.LastName);
                        cm.Parameters.AddWithValue("@height", p.Height);
                        cm.Parameters.AddWithValue("@weight", p.Weight);

                        // Open the connection
                        con.Open();

                        // Execute the SQL query to get a number of row affected
                        result = cm.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return result;
        }

        /// <summary>
        /// UpdatePerson method - to update a person record to the database from Person object
        /// </summary>
        /// <param name="p">A Person object, holds the person's data</param>
        public int UpdatePerson(Person p)
        {
            int result = 0;
            //add the logic for updating a person record in the database and returning the number of rows affected
            //NOTE: ensure all disposable objects are properly disposed and parameters are used for any SQL commands executed

            try
            {
                // SQL query to update an existing record in people table
                string query = "UPDATE people " +
                                "SET FirstName = @firstName, " +
                                    "LastName = @lastName, " +
                                    "Height = @height, " +
                                    "Weight = @weight " +
                                "WHERE Id = @id";

                // Establish the conection 
                // Use using statement to ensure that the ADO.NET SqlConnection and SqlCommand objects are correctly disposed
                using (SqlConnection con = new SqlConnection(_connectionString))
                {

                    // Pass the connection and the query to the SQL command
                    using (SqlCommand cm = new SqlCommand(query, con))
                    {
                        cm.Parameters.AddWithValue("@firstName", p.FirstName);
                        cm.Parameters.AddWithValue("@lastName", p.LastName);
                        cm.Parameters.AddWithValue("@height", p.Height);
                        cm.Parameters.AddWithValue("@weight", p.Weight);
                        cm.Parameters.AddWithValue("@id", p.Id);

                        // Open the connection
                        con.Open();

                        // Execute the SQL query to get a number of row affected
                        result = cm.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return result;
        }

        /// <summary>
        /// DeletePerson method - to delete a person record from the database
        /// </summary>
        /// <param name="p">A Person object, holds the person's data</param>
        public int DeletePerson(Person p)
        {
            int result = 0;
            //add the logic for deleting a person record in the database and returning the number of rows affected
            //NOTE: ensure all disposable objects are properly disposed and parameters are used for any SQL commands executed

            try
            {
                // SQL query to delete a record from people table
                string query = "DELETE FROM people WHERE Id = @id";

                // Establish the conection 
                // Use using statement to ensure that the ADO.NET SqlConnection and SqlCommand objects are correctly disposed
                using (SqlConnection con = new SqlConnection(_connectionString))
                {

                    // Pass the connection and the query to the SQL command
                    using (SqlCommand cm = new SqlCommand(query, con))
                    {
                        cm.Parameters.AddWithValue("@id", p.Id);

                        // Open the connection
                        con.Open();

                        // Execute the SQL query to get a number of row affected
                        result = cm.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return result;
        }
    }
}
