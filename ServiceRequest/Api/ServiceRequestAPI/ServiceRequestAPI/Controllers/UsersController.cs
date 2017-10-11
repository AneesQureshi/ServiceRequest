using ServiceRequestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceRequestAPI.Controllers
{
    public class UsersController : ApiController
    {
        [Route("api/Users/LogIn/{email}/{password}")]
        [HttpGet]
        public IHttpActionResult LogIn(string email, string password)
        {

            string role = "";
            Users user = new Users();


            try
            {
                role = user.ValidateUser(email, password);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Ok(role);
        }
    }
}
