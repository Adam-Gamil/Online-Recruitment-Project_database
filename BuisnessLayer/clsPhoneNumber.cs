using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BuisnessLayer
{
    public class clsPhoneNumber
    {
        
        public int phoneNumberID { get; set; }
        public string phoneNumber { get; set; }
        public int userID { get; set; }



        public clsPhoneNumber()
        {
            phoneNumberID = -1;
            userID = -1;
            phoneNumber = "";

        }
        

        private clsPhoneNumber(int phoneNumberID, string phoneNumber, int userID)
        {
            this.phoneNumberID = phoneNumberID;
            this.userID = userID;
            this.phoneNumber = phoneNumber;
        }


        public static DataTable findUserPhoneNumber(int userID)
        {

            return phoneNumberData.findUserPhoneNumber(userID);
        }


        public bool _AddNewUserPhoneNumber()
        {
            this.phoneNumberID = phoneNumberData.AddNewUserPhoneNumber(phoneNumber, userID);


            return (this.phoneNumberID != -1);

        }

     

    }
}
