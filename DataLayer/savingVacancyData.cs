using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class clssavingVacancyData
    {
        public static int AddNewSaving(int vacancyID, int jobSeekerID, DateTime savingDate)
        {
            int savingID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO SavingVacancy (vacancyID, jobSeekerID ,savingDate)
                             VALUES (@vacancyID, @jobSeekerID, @savingDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@vacancyID", vacancyID);
            command.Parameters.AddWithValue("@jobSeekerID", jobSeekerID);
            command.Parameters.AddWithValue("@savingDate", savingDate);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    savingID = insertedID;
                }
            }
            catch
            {
                savingID = -1;
            }
            finally
            {
                connection.Close();
            }

            return savingID;
        }

        public static DataTable GetSavedJobs(int jobSeekerID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                            SELECT SavingVacancy.savingID, vacancies.jobTitle, SavingVacancy.savingDate AS date
                            FROM SavingVacancy
                            INNER JOIN vacancies ON SavingVacancy.vacancyID = vacancies.vacancyID
                            WHERE SavingVacancy.jobSeekerID = @jobSeekerID";

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

        public static bool CheckIfSaved(int vacancyID, int jobSeekerID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found = 1 FROM SavingVacancy WHERE vacancyID = @vacancyID AND jobSeekerID = @jobSeekerID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@vacancyID", vacancyID);
            command.Parameters.AddWithValue("@jobSeekerID", jobSeekerID);
            int count = 0;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isFound = true;
                }
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        

        public static bool DeleteSaving(int savingID, int jobSeekerID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM SavingVacancy WHERE savingID = @savingID AND jobSeekerID = @jobSeekerID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@savingID", savingID);
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

