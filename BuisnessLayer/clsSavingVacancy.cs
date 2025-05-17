using System;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsSavingVacancy
    {
        public int savingID { get; set; }
        public int vacancyID { get; set; }
        public int jobseekerID { get; set; }
        public DateTime savingDate { get; set; }

        //Default Constructor
        public clsSavingVacancy() { }

        // Parametrized Constructor for initialzing the saving attributes
        public clsSavingVacancy(int savingID, int vacancyID, int jobseekerID, DateTime savingDate)
        {
            this.savingID = savingID;
            this.vacancyID = vacancyID;
            this.jobseekerID = jobseekerID;
            this.savingDate = savingDate;
        }

        
        
        public static string Save(int vacancyID, int jobseekerID)
        {
            DateTime now = DateTime.Now;

            int newID = clssavingVacancyData.AddNewSaving( vacancyID,  jobseekerID,  now);

            if (newID != -1)
                return $"Vacancy saved successfully with ID {newID}.";
            else
                return "Error: Failed to submit application.";
        }

        public static DataTable ShowSavedJobs(int jobseekerID)
        {
            return clssavingVacancyData.GetSavedJobs(jobseekerID);
            
        }

        public static bool CheckIfSaved(int vacancyID, int jobseekerID)
        {
            return clssavingVacancyData.CheckIfSaved(vacancyID, jobseekerID);
        }

        public static string DeleteSavedJob(int savingID, int jobseekerID)
        {
            bool success = clssavingVacancyData.DeleteSaving(savingID, jobseekerID);
            return success ? "Save deleted successfully." : "Failed to delete Save.";
        }
    }
}
