using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceRequest.Models;

namespace ServiceRequest.Controllers
{
    public class UserController : Controller
    {
       

        // GET: User
        public ActionResult UserHome()
        {

           
            return RedirectToAction("UserHome", "Admin");//opening view from other controller action
         
        }
    }
}