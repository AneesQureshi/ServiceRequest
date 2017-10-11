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

        public string webapiCheckUser(UserModel user)
        {


            string appservice = ConfigurationManager.AppSettings["ServiceRequestAPI"];
           
            string role = "";
           
            HttpResponseMessage response = null; // if   HttpResponseMessage dnt work then add in referece system.net,system.nethttp, system.net.formatiing  etc
            try
            {

                string struri2 = "/" + "api" + "/" + "Users" + "/" + "LogIn" + "/" + user.email + "/" + user.password;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(appservice);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync(struri2).Result;

                if (response != null || response.IsSuccessStatusCode)
                {

                    role = response.Content.ReadAsStringAsync().Result;

                }

                role = JsonConvert.DeserializeObject<string>(role);
                return role;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return role;
        }
    }
}