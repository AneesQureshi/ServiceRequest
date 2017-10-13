using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceRequestAPI.Models
{
    public class userModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string userName { get; set; }
    }
}