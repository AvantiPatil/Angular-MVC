using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using HospitalManagement.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using IdentityResult = Microsoft.AspNet.Identity.IdentityResult;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        

        // GET: api/<RegisterController>
        [HttpGet]
        [Authorize]
        [Route("api/GetUserClaims")]
       
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Register
        [HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        public IActionResult Post([FromBody] Registration obj)
        {

            // create the object of context

            var context = new ValidationContext(obj, null, null);

            //if there are errors then it will fill in ValidationResult collection

            var result = new List<ValidationResult>();

            //class says that validate the obj and if there is error then fill in result

            var isValid = Validator.TryValidateObject(obj, context, result, true);

            if (result.Count == 0)
            {
                PatientDAL dal = new PatientDAL();
                dal.Database.EnsureCreated(); // ensure table is created or not
                dal.Add(obj); // here obj is UI comming object //it adds in memory not in database
                dal.SaveChanges();// pysical commit save to database


                // return Json(recs);

                return StatusCode(200, result); // 200 for success 
            }
            else
            {
                return StatusCode(500, result); // 500 for internal server error
            }
        }

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
