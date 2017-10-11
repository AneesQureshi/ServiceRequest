using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

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

                string struri2 = "/" + "api" + "/" + "ServiceRequestController" + "/" + "LoadServiceRequest" + "/" ;
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
    }
}