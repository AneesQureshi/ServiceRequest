using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceRequestAPI.Models
{
    public class ServiceRequestModel
    {
        public string idsr { get; set; }
        public string userName { get; set; }
        public string emailId { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public string description { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public int userId { get; set; } // id of user table is foreign key in sr table

        //for loading admin service request details in a list 
        public List<ServiceRequestModel> loadServiceRequest()
        {

            List<ServiceRequestModel> sr1 = new List<ServiceRequestModel>();
            dbHelper db = new dbHelper();
            sr1 = db.LoadServiceRequest();
            return sr1;
        }

        //for loading description if click on view details
        public string loadDescription(string idsr)
        {

            string description = "";
            dbHelper db = new dbHelper();
            description = db.loadDescription(idsr);
            return description;
        }

        //for loading user service request details in a list 
        public List<ServiceRequestModel> loadUserServiceRequest(string email)
        {

            List<ServiceRequestModel> sr1 = new List<ServiceRequestModel>();
            dbHelper db = new dbHelper();
            sr1 = db.loadUserServiceRequest(email);
            return sr1;
        }

        public bool saveServiceRequest(ServiceRequestModel objsr)
        {

            bool Inserted = false;
            dbHelper db = new dbHelper();
            Inserted = db.saveServiceRequest(objsr);
           
            return Inserted;
        }

    }
}