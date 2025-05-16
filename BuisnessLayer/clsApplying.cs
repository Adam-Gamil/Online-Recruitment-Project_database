using System;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsApplying
    {
        public int applyingID { get; set; }
        public int vacancyID { get; set; }
        public int jobseekerID { get; set; }
        public string acceptanceStatus { get; set; }
        public DateTime applyingDate { get; set; }

        //Default Constructor
        public clsApplying() { }

        // Parametrized Constructor for initialzing the applying attributes
        public clsApplying(int applyingID, int vacancyID, int jobseekerID, string acceptanceStatus, DateTime applyingDate)
        {
            this.applyingID = applyingID;
            this.vacancyID = vacancyID;
            this.jobseekerID = jobseekerID;
            this.acceptanceStatus = acceptanceStatus;
            this.applyingDate = applyingDate;
        }

        
        // To-do => 1- check if the jobseekerID exists first
        public static string Apply(int vacancyID, int jobseekerID)
        {
            DateTime now = DateTime.Now;
            string status = "Pending";

            int newID = clsApplyingData.AddNewApplication( vacancyID,  jobseekerID,  status,  now);

            if (newID != -1)
                return $"Application submitted successfully with ID {newID}.";
            else
                return "Error: Failed to submit application.";
        }

        public static string ShowAppliedJobs(int jobseekerID)
        {
            DataTable dt = clsApplyingData.GetAppliedJobs(jobseekerID);
            if (dt == null || dt.Rows.Count == 0)
                return "No applied jobs found.";

            string result = "Applied Jobs:\n";
            foreach (DataRow row in dt.Rows)
            {
                result += $"[ID: {row["applyingID"]}] VacancyID: {row["vacancyID"]}, Status: {row["acceptanceStatus"]}, Date: {row["applyingDate"]}\n";
            }

            return result;
        }

        public static string DeleteAppliedJob(int applyingID, int jobseekerID)
        {
            bool success = clsApplyingData.DeleteApplication(applyingID, jobseekerID);
            return success ? "Application deleted successfully." : "Failed to delete application.";
        }
    }
}
