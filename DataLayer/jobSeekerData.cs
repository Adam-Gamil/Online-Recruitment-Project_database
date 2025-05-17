using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsJobSeekerData
    {




        public static bool FindJobSeekerByID(int jobSeekerID, ref string cv, ref string address, ref string educationLevel, ref string nationality, ref string favouriteWorkPlace, ref string experience, ref int userID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM JobSeekers WHERE jobSeekerID = @jobSeekerID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@jobSeekerID", jobSeekerID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    cv = (string)reader["cv"];
                    if (reader["address"] != DBNull.Value)
                    {
                        address = (string)reader["address"];
                    }
                    else
                    {
                        address = "";
                    }
                    educationLevel = (string)reader["educationLevel"];
                    nationality = (string)reader["nationality"];
                    favouriteWorkPlace = (string)reader["favouriteWorkPlace"];
                    experience = (string)reader["experience"];
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

        public static DataTable getAllJobSeekers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Users.userID,  Users.firstName, Users.lastName, Users.gender, Users.birthDate, Users.email, JobSeekers.jobSeekerID, JobSeekers.cv, JobSeekers.address, JobSeekers.educationLevel, JobSeekers.nationality, JobSeekers.favouriteWorkPlace, JobSeekers.experience FROM JobSeekers INNER JOIN Users ON JobSeekers.userID = Users.userID;";
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
                dt = null;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static int AddNewJobSeeker(string cv, string address, string educationLevel, string nationality, string favouriteWorkPlace, string experience, int userID)
        {
            int jobSeekerID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "INSERT INTO JobSeekers (cv, address, educationLevel, nationality, favouriteWorkPlace, experience, userID) " + " VALUES (@cv, @address, @educationLevel, @nationality, @favouriteWorkPlace, @experience, @userID);" + " SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@cv", cv);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@educationLevel", educationLevel);
            command.Parameters.AddWithValue("@nationality", nationality);
            command.Parameters.AddWithValue("@favouriteWorkPlace", favouriteWorkPlace);
            command.Parameters.AddWithValue("@experience", experience);
            command.Parameters.AddWithValue("@userID", userID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    jobSeekerID = insertedID;
                }
                else
                {
                    jobSeekerID = -1;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                jobSeekerID = -1;
            }
            finally
            {
                connection.Close();
            }
            return jobSeekerID;
        }


        public static bool UpdateJobSeeker(int jobSeekerID, string cv, string address, string educationLevel, string nationality, string favouriteWorkPlace, string experience)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "UPDATE JobSeekers SET cv = @cv, address = @address, educationLevel = @educationLevel, nationality = @nationality, favouriteWorkPlace = @favouriteWorkPlace, experience = @experience WHERE jobSeekerID = @jobSeekerID";
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@jobSeekerID", jobSeekerID);
            command.Parameters.AddWithValue("@cv", cv);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@educationLevel", educationLevel);
            command.Parameters.AddWithValue("@nationality", nationality);
            command.Parameters.AddWithValue("@favouriteWorkPlace", favouriteWorkPlace);
            command.Parameters.AddWithValue("@experience", experience);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
    }
}
