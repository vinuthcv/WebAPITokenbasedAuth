using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace WebAPITokenbasesAuth.Controllers
{
    public class EmployeesController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/employees/status")]
        public IHttpActionResult Get()
        {
            return Ok("Service is up and runnning at " + DateTime.UtcNow);
        }

        [Authorize]
        [HttpGet]
        [Route("api/employee")]
        public IHttpActionResult GetEmployee()
        {
            var identity = (ClaimsIdentity)User.Identity;

            return Ok("I am authorized " + identity.Name);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/employees")]
        public IHttpActionResult GetEmployees()
        {
            var identity = (ClaimsIdentity)User.Identity;

            return Ok("I am authorized " + identity.Name);
        }
    }
}
