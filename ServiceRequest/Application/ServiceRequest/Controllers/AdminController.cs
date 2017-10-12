using ServiceRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ServiceRequest.Controllers
{
    public class AdminController : Controller
    {
        
        // GET: Admin
        public ActionResult AdminHome()
        {
            if (Session["email"] != null)
            {
                ServiceRequestModel objSr = new ServiceRequestModel();
                List<ServiceRequestModel> sr = new List<ServiceRequestModel>();
                sr = objSr.LoadServiceRequestAPI();
                return View(sr);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Login");
        }
        
        public ActionResult UserHome()
        {
            if (Session["email"] != null)
            {
                string email = (string)Session["email"];

                ServiceRequestModel objSr = new ServiceRequestModel();
                List<ServiceRequestModel> sr = new List<ServiceRequestModel>();
                sr = objSr.loadUserServiceRequestAPI(email);
                return View("AdminHome",sr);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}