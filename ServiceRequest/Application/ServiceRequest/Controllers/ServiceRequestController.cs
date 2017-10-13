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
            if (Session["email"] != null)
            {
                string email = (string)Session["email"];
            //generating random emailid and adding in the object of sr below
            Random rnd = new Random();
            int idRandom = rnd.Next(10000000, 99999999); // creates a 8 digit random no.
            objsr.idsr = idRandom.ToString();
            bool flag=objsr.saveServiceRequestAPI(objsr,email);

            ServiceRequestModel objSr1 = new ServiceRequestModel();
            if (flag == true)
            {
                TempData["message"] = "Service request added successfully";
                return RedirectToAction("addRequest", "View",objSr1);
               
            }
            else
            {
                TempData["message"] = "Oops! Please try again later.";
                return RedirectToAction("addRequest", "View",objSr1);
            }

        }
            else
            {
                return RedirectToAction("Index", "Login");
    }

}

        public ActionResult Resolve(ServiceRequestModel objsr)
        {
            if (Session["email"] != null)
            {

                bool flag = objsr.resolveServiceRequestAPI(objsr);

           
            if (flag == true)
            {
                TempData["message"] = "Service request Resolved";
                return RedirectToAction("AdminHome", "Admin",objsr);

            }
            else
            {
                TempData["message"] = "Oops! Please try again later.";
                return RedirectToAction("AdminHome", "Admin", objsr);
            }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


        }
    }
}