using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

using Newtonsoft.Json;

namespace ServiceRequest.Models
{
    public class UserModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string userName { get; set; }

        public UserModel webapiCheckUser(UserModel user)
        {


            string appservice = ConfigurationManager.AppSettings["ServiceRequestAPI"];

            string result = "";
            UserModel objuser = new UserModel();
           
            HttpResponseMessage response = null; // if   HttpResponseMessage dnt work then add in referece system.net,system.nethttp, system.net.formatiing  etc
            try
            {
                //this has to be uncomment before publish 

                //string appFolderName = "Service_Request_Api"; 
                string appFolderName = ConfigurationManager.AppSettings["appFolderName"]; ;
                string struri2 = appFolderName + "/" + "api" + "/" + "Users" + "/" + "LogIn" + "/" + user.email + "/" + user.password;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(appservice);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync(struri2).Result;

                if (response != null || response.IsSuccessStatusCode)
                {

                    result = response.Content.ReadAsStringAsync().Result;

                }

                objuser = JsonConvert.DeserializeObject<UserModel>(result);
                return objuser;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return objuser;
        }
    }
}