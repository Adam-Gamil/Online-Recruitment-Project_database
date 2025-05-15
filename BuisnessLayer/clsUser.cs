using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BuisnessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int userID { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }
        public string gender { get; set; }

        public DateTime birthDate { get; set; }

        public string email { get; set; }



        public clsUser()
        {
            userID = -1;
            firstName = "";
            lastName = "";
            gender = "";
            birthDate = DateTime.Now;
            email = "";
            Mode = enMode.AddNew;
        }
        

        private clsUser(int userID, string firstName, string lastName, string gender, DateTime birthDate, string email)
        {
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthDate = birthDate;
            this.email = email;
            Mode = enMode.Update;

        }


        public static clsUser findUser(int ID)
        {
            string firstName = "";
            string lastName = "";
            string gender = "";
            DateTime birthDate = DateTime.Now;
            string email = "";
            
            if(userData.findUserByID(ID, ref firstName, ref lastName, ref gender, ref birthDate, ref email)){

                return new clsUser(ID, firstName, lastName, gender, birthDate, email);  
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewUser()
        {
            this.userID = userData.AddNewUser(firstName, lastName, gender, birthDate, email);


            return (this.userID != -1);

        }

        private bool _UpdateUser()
        {
            return userData.UpdateUser(this.userID, this.firstName, this.lastName, this.gender, this.birthDate, this.email);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:


                    return _UpdateUser();
            }

            return false;
        }

    }
}
