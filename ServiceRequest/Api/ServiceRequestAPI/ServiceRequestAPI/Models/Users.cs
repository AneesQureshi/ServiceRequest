﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceRequestAPI.Models
{
    public class Users
    {
        public string email { get; set; }
        public string password { get; set; }
   
        public string role { get; set; }
        public string userName { get; set; }

        public Users ValidateUser(string email, string pwd)
        {

            Users obju = new Users();
            dbHelper db = new dbHelper();
            obju = db.ValidateUser(email, pwd);

          
            return obju;
        }
    }
}