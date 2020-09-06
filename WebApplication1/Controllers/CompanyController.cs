using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.DBHelper;
using System.Text;

namespace WebApplication1.Controllers
{
    public class CompanyController : ApiController
    {
        [Route("api/company/createcompany")]
        [HttpPost]
        public HttpResponseMessage CreateCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                
                DBOparations dbOparation = new DBOparations();
                dbOparation.InsertCompany(company);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("api/user/getcompanylist")]
        [HttpPost]
        public HttpResponseMessage GetCompany()
        {
            DBOparations dbOparation = new DBOparations();
            string json = dbOparation.GetCompanyInfo();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            return response;

        }
    }
}
