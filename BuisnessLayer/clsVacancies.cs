using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BuisnessLayer
{
    public class clsVacancies
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int vacancyID { get; set; }
        public int employerID
        {
            get { return employer.employerID; }
        }
        public clsEmployer employer { get; set; }
        public string industry {  get; set; }
        public double salary {  get; set; }
        public string requiredExperience {  get; set; }
        public DateTime postDate {  get; set; }
        public string jobStatus {  get; set; }
        public string location {  get; set; }
        public string description {  get; set; }
        public string jobTitle { get; set; }

        public clsVacancies()
        {
            vacancyID = -1;
            industry = "";
            salary = -1;
            requiredExperience = "";
            postDate = DateTime.Now;
            jobStatus = "";
            location = "";
            description = "";
            jobTitle = "";
            employer = new clsEmployer();
            Mode = enMode.AddNew;
        }
        private clsVacancies(int vacancyID, string industry ,double salary, string requiredExperience, DateTime postDate, string location, string jobStatus,string description,string jobTitle, clsEmployer employer)
        {
            this.vacancyID = vacancyID;
            this.industry = industry;
            this.salary = salary;
            this.requiredExperience = requiredExperience;
            this.postDate = postDate;
            this.location = location;
            this.jobStatus = jobStatus;
            this.description = description;
            this.jobTitle = jobTitle;
            this.employer = employer;
            Mode = enMode.Update;
        }
        public static clsVacancies FindVacancyByID(int vacancyID)
        {
            string industry = "";
            double salary = -1;
            string requiredExperience = "";
            DateTime postDate = DateTime.Now;
            string jobStatus = "";
            string location = "";
            string description = "";
            string jobTitle = "";
            int employerID = -1;
            if (clsVacanciesData.FindVacancyByID(vacancyID, ref employerID, ref industry, ref jobTitle, ref description, ref location, ref jobStatus, ref postDate, ref requiredExperience, ref salary))
            {
                clsEmployer employer = clsEmployer.FindEmployerByID(employerID);
                if (employer != null)
                {
                    return new clsVacancies(vacancyID, industry, salary, requiredExperience, postDate, location, jobStatus, description, jobTitle, employer);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewVacancy()
        {
            if (!employer.Save())
            {
                return false;
            }

            this.vacancyID = clsVacanciesData.AddNewVacancy(employerID, industry, jobTitle, description, location, jobStatus, postDate, requiredExperience, salary);

            return (this.vacancyID != -1);
        }
        private bool _UpdateVacancy()
        {
            if (!employer.Save())
            {
                return false;
            }

            return clsVacanciesData.UpdateVacancy(this.vacancyID, this.industry, this.jobTitle, this.description, this.location, this.jobStatus, this.postDate, this.requiredExperience, this.salary);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewVacancy())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:


                    return _UpdateVacancy();
            }

            return false;
        }
    }

}
