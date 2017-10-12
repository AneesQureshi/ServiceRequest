using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceRequest.Models;

namespace ServiceRequest.Controllers
{
    public class ServiceRequestController : Controller
    {
        // GET: ServiceRequest
        public ActionResult Index()
        {
            return View();
        }

        //for saving service request in db
        public ActionResult AddRequest(ServiceRequestModel objsr)
        {
            string email = (string)Session["email"];
            bool flag=objsr.saveServiceRequestAPI(objsr,email);
           

            if (flag == true)
            {
                TempData["message"] = "Service request added successfully";
                return View();
            }
            else
            {
                TempData["message"] = "Oops! Please try again later.";
                return View();
            }
            
        }
    }
}