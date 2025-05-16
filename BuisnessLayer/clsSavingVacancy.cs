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

        
        // To-do => 1- check if the jobseekerID exists first
        public static string Save(int vacancyID, int jobseekerID)
        {
            DateTime now = DateTime.Now;

            int newID = clssavingVacancyData.AddNewSaving( vacancyID,  jobseekerID,  now);

            if (newID != -1)
                return $"Application submitted successfully with ID {newID}.";
            else
                return "Error: Failed to submit application.";
        }

        //public static string ShowSavedJobs(int jobseekerID)
        //{
        //    DataTable dt = clssavingVacancyData.GetSavedJobs(jobseekerID);
        //    if (dt == null || dt.Rows.Count == 0)
        //        return "No Saved jobs found.";

        //    string result = "Saved Jobs:\n";
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        result += $"[Saving ID: {row["savingID"]}] VacancyID: {row["vacancyID"]}, Date: {row["savingDate"]}\n";
        //    }

        //    return result;
        //}

        public static string DeleteSavedJob(int savingID, int jobseekerID)
        {
            bool success = clssavingVacancyData.DeleteSaving(savingID, jobseekerID);
            return success ? "Save deleted successfully." : "Failed to delete Save.";
        }
    }
}
