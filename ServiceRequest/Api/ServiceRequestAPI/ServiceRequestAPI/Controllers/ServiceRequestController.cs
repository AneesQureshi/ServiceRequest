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
                sr1 = sr.LoadServiceRequest();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Ok(sr1);
        }
    }
}
