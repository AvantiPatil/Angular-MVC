using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using HospitalManagement.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using WebApplication3.Models;

namespace HospitalManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAPIController : ControllerBase
    {
        string constr = "";
        public PatientAPIController(IConfiguration configuration)
        {
            constr = configuration["ConnStr"];
        }

        [EnableCors("AllowOriginRule")]
        // GET: api/PatientAPI
        [HttpGet]
        //  public IEnumerable<string> Get()
        //  {
        //      return new string[] { "value1", "value2" };
        //  }

        public IActionResult Get(string patientName)
        {
            PatientDAL dal = new PatientDAL(constr);
            List<Patient> search = (from temp in dal.PatientModels
                                         where temp.name == patientName
                                         select temp)
                                         .ToList<Patient>();

           
            return Ok(search);
        }
        

        // GET: api/PatientAPI/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PatientAPI
        [HttpPost]
        //  public void Post([FromBody] string value)
        // {
        // }


        public IActionResult Post([FromBody] Patient obj)
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


                List<Patient> recs = dal.PatientModels.Include(pat =>pat.problems)
                    .ToList<Patient>();
                // return Json(recs);

                return Ok(recs); // 200 for success 
            }
            else
            {
                return StatusCode(500, result); // 500 for internal server error
            }
        }
        

        // PUT: api/PatientAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

   
}
