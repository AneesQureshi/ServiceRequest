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


        public List<ServiceRequestModel> LoadServiceRequest()
        {

            List<ServiceRequestModel> sr1 = new List<ServiceRequestModel>();
            dbHelper db = new dbHelper();
            sr1 = db.LoadServiceRequest();
            return sr1;
        }

    }
}