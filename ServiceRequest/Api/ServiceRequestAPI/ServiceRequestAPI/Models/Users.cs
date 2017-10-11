using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceRequestAPI.Models
{
    public class Users
    {
        public string email { get; set; }
        public string password { get; set; }

        public string ValidateUser(string email, string pwd)
        {
            
            string role = "";
            dbHelper db = new dbHelper();
            role = db.ValidateUser(email, pwd);

          
            return role;
        }
    }
}