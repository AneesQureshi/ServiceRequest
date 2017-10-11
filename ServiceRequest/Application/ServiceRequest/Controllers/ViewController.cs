﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceRequest.Models;

namespace ServiceRequest.Controllers
{
    public class ViewController : Controller
    {
        // GET: ViewDetail
        [HttpGet]
        public ActionResult ViewDetail(string idsr,string title, string category, string subCategory, string priority, string status)
        {
            ServiceRequestModel objsr = new ServiceRequestModel();
            objsr.idsr = idsr;
            objsr.title = title;
            objsr.category = category;
            objsr.subCategory = subCategory;
            objsr.priority = priority;
            objsr.status = status;

            return View(objsr);
        }
    }
}