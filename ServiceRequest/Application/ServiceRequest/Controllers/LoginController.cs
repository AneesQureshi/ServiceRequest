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
                Session["email"] = objUserModel.email;
                string role = objUserModel.webapiCheckUser(objUserModel);
                Session["role"] = role;

                if (role == "admin")
                    return RedirectToAction("AdminHome", "Admin");

                else if (role == "user")
                {
                    
                    return RedirectToAction("UserHome", "User");
                }
                    
                        

            }
            TempData["message"] = "Invalid username or password";
            return RedirectToAction("Index");

        }
    }
}