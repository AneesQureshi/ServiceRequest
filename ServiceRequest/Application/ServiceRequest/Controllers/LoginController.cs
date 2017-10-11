using ServiceRequest.Models;
using ServiceRequest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ServiceRequest.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Check(LoginViewModel objloginView)
        {
            UserModel objUserModel = new UserModel();
            objUserModel.email = objloginView.email;
            objUserModel.password = objloginView.password;
            if (ModelState.IsValid)
            {
                string role = objUserModel.webapiCheckUser(objUserModel);

                if (role == "admin")
                    return RedirectToAction("AdminHome", "Admin");

                else if (role == "user")
                   return RedirectToAction("UserHome", "User",objUserModel.email);
                
            }
            TempData["message"] = "Invalid username or password";
            return RedirectToAction("Index");

        }
    }
}