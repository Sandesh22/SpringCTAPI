using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;
using WebApplication1.DBHelper;
using System.Text;

namespace WebApplication1.Controllers
{
    public class UserController : ApiController
    {

        [Route("api/user/createuser")]
        [HttpPost]
        public HttpResponseMessage CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                DBOparations dbOparation = new DBOparations();
                dbOparation.InsertUser(user);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("api/user/assignuserincompany")]
        [HttpPost]
        public HttpResponseMessage AssignUserInCompany(int userID, string companyIDs)
        {
            DBOparations dbOparation = new DBOparations();
            dbOparation.AssignUserInCompany(userID, companyIDs);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("api/user/getuserdata")]
        [HttpPost]
        public HttpResponseMessage GetUserData()
        {
            DBOparations dbOparation = new DBOparations();
            string json = dbOparation.GetUserCompanyInfo();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            return response;
            
        }

        [Route("api/user/getuserlist")]
        [HttpPost]
        public HttpResponseMessage GetUser()
        {
            DBOparations dbOparation = new DBOparations();
            string json = dbOparation.GetUserInfo();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            return response;

        }

    }
}
