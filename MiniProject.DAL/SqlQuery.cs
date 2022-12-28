using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.DAL
{
    public class SqlQuery
    {
        //Pointer To Function
        static string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\SQLEXPRESS";
        public delegate object SetDataReader_delegate(SqlDataReader reader);
        //Function that returns information from database and send the inforamtion to another function 
        //SqlDataReader reader contains all the information in sql database 
        //the variable reader is sent to ReadFromDb function the create instances of student class and insert then in Hashtable as a value and id as a key
        public static object StartReadFromDB(string SqlQuery, SetDataReader_delegate Ptrfunc)
        {
            object retHash = null;
            //string connectionString = ConfigurationManager.AppSettings["connectionString"];
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                // Adapter
                using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                {
                    connection.Open();
                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        retHash = Ptrfunc(reader);
                        return retHash;
                    }
                }
            }
        }

        //Function that input to DB row of information about student
        //Paramater is used to set the right values
        /*ExecuteNonQuery is a method of the SqlCommand class in the .NET Framework that is used to execute a Transact-SQL statement or stored procedure against a SQL Server database. 
         * The ExecuteNonQuery method returns an integer value that indicates the number of rows affected by the SQL statement or stored procedure.
         * The ExecuteNonQuery method is typically used to execute SQL statements that do not return any data, such as INSERT, UPDATE, or DELETE statements. */


        public static void InputToDB(string SqlQuery)
        {

            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = SqlQuery;

                connection.Open();

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();

                }
            }
        }





        public static void DeleteFromSqlServer(string SqlQuery, int ProductID)
        {

        
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = SqlQuery;

                connection.Open();

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@productID", ProductID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateRowById(string updateQuery, int productID, int categoryID, int unitsInStock)
        {


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a new SQL command
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {

                        // Add the parameters for the command
                        command.Parameters.AddWithValue("@productID", productID);
                        command.Parameters.AddWithValue("@categoryID", categoryID);
                        command.Parameters.AddWithValue("@unitsInStock", unitsInStock);

                        //Execute the command
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    
    }
}