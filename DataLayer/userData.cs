using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class userData
    {
        public static bool findUserByID(int userID, ref string firstName, ref string lastName, ref string gender, ref DateTime birthDate, ref string email)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE userID = @userID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userID", userID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    firstName = (string)reader["firstName"];
                    lastName = (string)reader["lastName"];
                    gender = (string)reader["gender"];

                    if(reader["birthDate"] != DBNull.Value)
                    {
                        birthDate = (DateTime)reader["birthDate"];
                    }
                    else
                    {
                        birthDate = DateTime.MinValue;
                    }

                    email = (string)reader["email"];
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


        public static int AddNewUser(string firstName, string lastName, string gender, DateTime birthDate, string email)
        {
            int userID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [USERS] (firstName, lastName, gender, birthDate, email) VALUES (@firstName, @lastName, @gender, @birthDate, @email); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@gender", gender);
            if(birthDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@birthDate", birthDate);
            }
            else
            {
                command.Parameters.AddWithValue("@birthDate", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@email", email);
            

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    userID = insertedID;
                }
                else
                {
                    userID = -1;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error in AddNewUser: " + ex.Message);
                userID = -1;
            }
            finally
            {
                connection.Close();
            }
            return userID;
        }

        public static bool UpdateUser(int userID, string firstName, string lastName, string gender, DateTime birthDate, string email)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "UPDATE Users SET firstName = @firstName, lastName = @lastName, gender = @gender, birthDate = @birthDate, email = @email WHERE userID = @userID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userID", userID);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@gender", gender);
            if (birthDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@birthDate", birthDate);
            }
            else
            {
                command.Parameters.AddWithValue("@birthDate", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@email", email);

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
