using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BuisnessLayer
{
    public class clsJobSeeker
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int jobSeekerID { get; set; }
        public string cv { get; set; }
        public string address { get; set; }
        public string educationLevel { get; set; }
        public string nationality { get; set; }
        public string favouriteWorkPlace { get; set; }
        public string experience { get; set; }

        public int userID
        {
            get { return user.userID; }
        }
        public clsUser user { get; set; }  


        public clsJobSeeker()
        {
            jobSeekerID = -1;
            cv = "";
            address = "";
            educationLevel = "";
            nationality = "";
            favouriteWorkPlace = "";
            experience = "";
            user = new clsUser();
            Mode = enMode.AddNew;
        }


        private clsJobSeeker(int jobSeekerID, string cv, string address, string educationLevel, string nationality, string favouriteWorkPlace, string experience, clsUser user)
        {
            this.jobSeekerID = jobSeekerID;
            this.cv = cv;
            this.address = address;
            this.educationLevel = educationLevel;
            this.nationality = nationality;
            this.favouriteWorkPlace = favouriteWorkPlace;
            this.experience = experience;
            this.user = user;
            Mode = enMode.Update;
        }


        public static clsJobSeeker FindJobSeekerByID(int jobSeekerID)
        {
            string cv = "";
            string address = "";
            string educationLevel = "";
            string nationality = "";
            string favouriteWorkPlace = "";
            string experience = "";
            int userID = -1;
            if (clsJobSeekerData.FindJobSeekerByID(jobSeekerID, ref cv, ref address, ref educationLevel, ref nationality, ref favouriteWorkPlace, ref experience, ref userID))
            {
                clsUser user = clsUser.findUser(userID);
                if (user != null)
                {
                    return new clsJobSeeker(jobSeekerID, cv, address, educationLevel, nationality, favouriteWorkPlace, experience, user);
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

        private bool _AddNewJobSeeker()
        {
            if (!user.Save())
            {
                return false;
            }

            this.jobSeekerID = clsJobSeekerData.AddNewJobSeeker(cv, address, educationLevel, nationality, favouriteWorkPlace, experience, user.userID);

            return (this.jobSeekerID != -1);
        }

        private bool _UpdateJobSeeker()
        {
            if (!user.Save())
            {
                return false;
            }

            return clsJobSeekerData.UpdateJobSeeker(this.jobSeekerID, this.cv, this.address, this.educationLevel, this.nationality, this.favouriteWorkPlace, this.experience);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewJobSeeker())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:


                    return _UpdateJobSeeker();
            }

            return false;
        }

    }
}
