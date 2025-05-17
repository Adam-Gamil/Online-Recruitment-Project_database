using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsVacanciesData
    {
        public static bool FindVacancyByID(int vacancyID, ref int employerID, ref string industry, ref string jobTitle , ref string description, ref string location, ref string jobStatus, ref DateTime postDate , ref string requiredExperience, ref double salary)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Vacancies WHERE vacancyID = @vacancyID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@vacancyID", vacancyID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    employerID = (int)reader["employerID"];
                    industry = (string)reader["industry"];
                    jobTitle = (string)reader["jobTitle"];
                    description = (string)reader["description"];
                    location = (string)reader["location"];
                    jobStatus = (string)reader["jobStatus"];
                    if (reader["postDate"] != DBNull.Value)
                    {
                        postDate = (DateTime)reader["postDate"];
                    }
                    else
                    {
                        postDate = DateTime.MinValue;
                    }
                    requiredExperience = (string)reader["requiredExperience"];
                    salary = (double)reader["salary"];
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


        public static DataTable getAllVacancies()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From Vacancies;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                table = null;
            }
            finally
            {
                connection.Close();
            }
            return table;
        }

        public static DataTable getVacanciesByEmployerID(int employerID)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From Vacancies Where employerID = @employerID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@employerID", employerID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                table = null;
            }
            finally
            {
                connection.Close();
            }
            return table;
        }
        public static int AddNewVacancy(int employerID, string industry, string jobTitle, string description, string location, string jobStatus, DateTime postDate, string requiredExperience, double salary)
        {
            int vacancyID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "INSERT INTO Vacancies (employerID, industry,jobTitle, description,location, jobStatus, postDate, requiredExperience, salary) " + " VALUES (@employerID, @industry,@jobTitle, @description,@location, @jobStatus, @postDate, @requiredExperience, @salary);" + " SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@employerID", employerID);
            command.Parameters.AddWithValue("@industry", industry);
            command.Parameters.AddWithValue("@jobTitle", jobTitle);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@location", location);
            command.Parameters.AddWithValue("@jobStatus", jobStatus);
            command.Parameters.AddWithValue("@postDate", postDate);
            command.Parameters.AddWithValue("@requiredExperience", requiredExperience);
            command.Parameters.AddWithValue("@salary", salary);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    vacancyID = insertedID;
                }
                else
                {
                    vacancyID = -1;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                vacancyID = -1;
            }
            finally
            {
                connection.Close();
            }
            return vacancyID;
        }


        public static bool UpdateVacancy(int vacancyID, string industry, string jobTitle, string description, string location, string jobStatus, DateTime postDate, string requiredExperience, double salary)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "UPDATE Vacancies SET industry = @industry, jobTitle = @jobTitle, description = @description, location = @location, jobStatus = @jobStatus, postDate = @postDate, requiredExperience = @requiredExperience, salary = @salary WHERE vacancyID = @vacancyID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@industry", industry);
            command.Parameters.AddWithValue("@jobTitle", jobTitle);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@vacancyID", vacancyID);
            command.Parameters.AddWithValue("@location", location);
            command.Parameters.AddWithValue("@jobStatus", jobStatus);
            command.Parameters.AddWithValue("@postDate", postDate);
            command.Parameters.AddWithValue("@requiredExperience", requiredExperience);
            command.Parameters.AddWithValue("@salary", salary);
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
