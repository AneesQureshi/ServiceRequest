using ServiceRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceRequest.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminHome()
        {
            ServiceRequestModel objSr = new ServiceRequestModel();
            List<ServiceRequestModel> sr = new List<ServiceRequestModel>();
           sr= objSr.LoadServiceRequestAPI();
            return View(sr);
        }
    }
}