using ServiceRequestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceRequestAPI.Controllers
{
    public class ServiceRequestController : ApiController
    {
        [Route("api/ServiceRequestController/loadServiceRequest")]
        [HttpGet]
        public IHttpActionResult loadServiceRequest()
        {


            ServiceRequestModel sr = new ServiceRequestModel();
            List<ServiceRequestModel> sr1 = new List<ServiceRequestModel>();
            try
            {
                sr1 = sr.loadServiceRequest();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Ok(sr1);
        }


        [Route("api/ServiceRequestController/loadDescriptionAPI/{idsr}")]
        [HttpGet]
        public IHttpActionResult loadDescriptionAPI(string idsr)
        {

            string description = "";
            ServiceRequestModel sr = new ServiceRequestModel();
           
            try
            {
                description = sr.loadDescription(idsr);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Ok(description);
        }

        [Route("api/ServiceRequestController/loadUserServiceRequest/{email}")]
        [HttpGet]
        public IHttpActionResult loadUserServiceRequest(string email)
        {


            ServiceRequestModel sr = new ServiceRequestModel();
            List<ServiceRequestModel> sr1 = new List<ServiceRequestModel>();
            try
            {
                sr1 = sr.loadUserServiceRequest(email);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Ok(sr1);
        }

        [Route("api/ServiceRequestController/saveServiceRequestAPI")]
        [HttpPost]
        public IHttpActionResult Insert(ServiceRequestModel objsr)
        {

            bool Inserted = false;

            Users user1 = new Users();
            try
            {
                Inserted = objsr.saveServiceRequest(objsr);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return Ok(Inserted);
        }
    }
}
