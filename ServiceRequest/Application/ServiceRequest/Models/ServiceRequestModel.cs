using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ServiceRequest.Models
{
    public class ServiceRequestModel
    {

      
        [Display(Name = "SR#")]  // Set the display name of the field
        public string idsr { get; set; }
       
        public string userName { get; set; }
     
        public string emailId { get; set; }
        
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Category")]
        public string category { get; set; }
        [Display(Name = "Sub-Category")]
        public string subCategory { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Priority ")]
        public string priority { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
       
        public int userId { get; set; } // id of user table is foreign key in sr table


        public List<ServiceRequestModel> LoadServiceRequestAPI()
        {


            string appservice = ConfigurationManager.AppSettings["ServiceRequestAPI"];
            string result = "";
            List<ServiceRequestModel> sr = new List<ServiceRequestModel>();

            HttpResponseMessage response = null; // if   HttpResponseMessage dnt work then add in referece system.net,system.nethttp, system.net.formatiing  etc
            try
            {
                //this has to be uncomment before publish 

                //string appFolderName = "Service_Request_Api"; 
                string appFolderName = "";
                string struri2 = appFolderName + "/" + "api" + "/" + "ServiceRequestController" + "/" + "loadServiceRequest" + "/" ;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(appservice);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync(struri2).Result;

                if (response != null || response.IsSuccessStatusCode)
                {

                    result = response.Content.ReadAsStringAsync().Result;

                }

                sr = JsonConvert.DeserializeObject<List<ServiceRequestModel>>(result);


                return sr;



            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return sr;
        }


        public string loadDescriptionAPI(string idsr)
        {


            string appservice = ConfigurationManager.AppSettings["ServiceRequestAPI"];
            string description = "";
           

            HttpResponseMessage response = null; // if   HttpResponseMessage dnt work then add in referece system.net,system.nethttp, system.net.formatiing  etc
            try
            {
                //this has to be uncomment before publish 

                //string appFolderName = "Service_Request_Api"; 
                string appFolderName = "";
                string struri2 = appFolderName + "/" + "api" + "/" + "ServiceRequestController" + "/" + "loadDescriptionAPI" + "/"+idsr+"/";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(appservice);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync(struri2).Result;

                if (response != null || response.IsSuccessStatusCode)
                {

                    description = response.Content.ReadAsStringAsync().Result;

                }


                description = JsonConvert.DeserializeObject<string>(description);

                return description;


            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return description;
        }
    }
}