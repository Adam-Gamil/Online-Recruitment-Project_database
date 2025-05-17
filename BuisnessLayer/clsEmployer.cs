using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BuisnessLayer
{
    public class clsEmployer
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int employerID { get; set; }

        public string companyName { get; set; }

        public string companyLocation { get; set; }

        public int userID
        {
            get { return user.userID; }
        }
        public clsUser user { get; set; }


        public clsEmployer()
        {
            employerID = -1;
            companyName = "";
            companyLocation = "";
            user = new clsUser();
            Mode = enMode.AddNew;
        }


        private clsEmployer(int employerID, string companyName, string companyLocation, clsUser user)
        {
            this.employerID = employerID;
            this.companyName = companyName;
            this.companyLocation = companyLocation;
            this.user = user;
            Mode = enMode.Update;
        }

      
        public static clsEmployer FindEmployerByID(int employerID)
        {
            
            string companyName = "";
            string companyLocation = "";
            int userID = -1;
            if (clsEmployerData.FindEmployerByID(employerID, ref companyName, ref companyLocation, ref userID))
            {
               clsUser user = clsUser.findUser(userID);
                if (user != null)
                {
                    return new clsEmployer(employerID, companyName, companyLocation, user);
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

        public static DataTable getAllEmployers()
        {
          
            return clsEmployerData.getAllEmployers(); 
        }

        private bool _AddNewEmployer()
        {
            if (!user.Save())
            {
                return false;
            }
            employerID = clsEmployerData.AddNewEmployer(companyName, companyLocation, user.userID);

            return (employerID != -1);
        }

        private bool _UpdateEmployer()
        {
            if (!user.Save())
            {
                return false;
            }
            return clsEmployerData.UpdateEmployer(employerID, companyName, companyLocation);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEmployer())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:


                    return _UpdateEmployer();
            }

            return false;
        }
    }
}
