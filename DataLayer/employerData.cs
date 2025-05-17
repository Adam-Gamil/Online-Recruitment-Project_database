using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsEmployerData
    {



        public static bool FindEmployerByID(int employerID, ref string companyName, ref string companyLocation, ref int userID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Employers WHERE employerID = @employerID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@employerID", employerID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    companyName = (string)reader["companyName"];
                    companyLocation = (string)reader["companyLocation"];
                    userID = (int)reader["userID"];
                  
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        public static DataTable getAllEmployers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Users.userID,  Users.firstName, Users.lastName, Users.gender, Users.birthDate, Users.email, Employers.employerID, Employers.companyName,  Employers.companyLocation FROM Employers INNER JOIN Users ON Employers.userID = Users.userID;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int AddNewEmployer(string companyName, string companyLocation, int userID)
        {
            int employerID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "INSERT INTO Employers (companyName, companyLocation, userID) " +
                           " VALUES (@companyName, @companyLocation, @userID);" +
                           " SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@companyName", companyName);
            command.Parameters.AddWithValue("@companyLocation", companyLocation);
            command.Parameters.AddWithValue("@userID", userID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    employerID = insertedID;
                }
                else
                {
                    employerID = -1;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                employerID = -1;
            }
            finally
            {
                connection.Close();

            }
            return employerID;
        }
    

        public static bool UpdateEmployer(int employerID, string companyName, string companyLocation)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "UPDATE Employers SET companyName = @companyName, companyLocation = @companyLocation WHERE employerID = @employerID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@employerID", employerID);
            command.Parameters.AddWithValue("@companyName", companyName);
            command.Parameters.AddWithValue("@companyLocation", companyLocation);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                rowsAffected = -1;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
    }
}
