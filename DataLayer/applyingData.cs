using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class clsApplyingData
    {
        public static int AddNewApplication(int vacancyID, int jobSeekerID, string acceptanceStatus, DateTime applyingDate)
        {
            int applyingID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Applying (vacancyID, jobSeekerID, acceptanceStatus, applyingDate)
                             VALUES (@vacancyID, @jobSeekerID, @acceptanceStatus, @applyingDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@vacancyID", vacancyID);
            command.Parameters.AddWithValue("@jobSeekerID", jobSeekerID);
            command.Parameters.AddWithValue("@acceptanceStatus", acceptanceStatus);
            command.Parameters.AddWithValue("@applyingDate", applyingDate);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    applyingID = insertedID;
                }
            }
            catch
            {
                applyingID = -1;
            }
            finally
            {
                connection.Close();
            }

            return applyingID;
        }

        public static DataTable GetAppliedJobs(int jobSeekerID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Applying WHERE jobSeekerID = @jobSeekerID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@jobSeekerID", jobSeekerID);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool DeleteApplication(int applyingID, int jobSeekerID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM Applying WHERE applyingID = @applyingID AND jobSeekerID = @jobSeekerID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applyingID", applyingID);
            command.Parameters.AddWithValue("@jobSeekerID", jobSeekerID);

            int rowsAffected = 0;

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
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

