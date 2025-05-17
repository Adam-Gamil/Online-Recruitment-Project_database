using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class phoneNumberData
    {
      
        public static int AddNewUserPhoneNumber(string phoneNumber, int userID)
        {
            int phoneNumberID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "INSERT INTO PhoneNumbers (phoneNumber, userID) VALUES (@phoneNumber, @userID); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@userID", userID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    phoneNumberID = insertedID;
                }
            }
            catch (Exception ex)
            {
                // Optionally log or display the exception
                phoneNumberID = -1;
            }
            finally
            {
                connection.Close();
            }

            return phoneNumberID;
        }


        public static DataTable findUserPhoneNumber(int userID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM PhoneNumbers WHERE userID = @userID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userID", userID);
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
                Console.WriteLine("Error: " + ex.Message);
                dt = null;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}
