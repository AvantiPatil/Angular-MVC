using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication3.Models;
using Microsoft.AspNetCore.Authorization;
using HospitalManagement.DAL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class SecurityController : ControllerBase
    {
        public object Registration { get; private set; }
        public object Session { get; private set; }

        private ActionResult View(LoginModel model)
        {
            return View();
        }

        // GET: api/<SecurityController>


        private string GenerateKey(string userName)
        {
            // Key
            var securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes("absbshdshjdfkkekporkfklkrf"));
            // Algorithm
            var credentials = new
                    SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // claimns
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Email, ""),
                new Claim("Admin", "true"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken("finishingschool",
              "finishingschool",
              claims,
              expires: DateTime.Now.AddMinutes(2000),
              signingCredentials: credentials);

            string tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenstring;
        }

        // GET api/<SecurityController>/5
        [HttpGet("{Home}")]
        public ActionResult Login()
        {
            return View();
        }

        private ActionResult View()
        {
            throw new NotImplementedException();
        }

        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<SecurityController>

        [HttpPost]
        public IActionResult Post([FromBody] LoginModel obj)
        {
            PatientDAL dal = new PatientDAL();
            if (ModelState.IsValid)
            {
                using (var Dbcontext = new PatientDAL())
                {
                    
                    List<Registration> search = (from u in dal.Registrations
                                      .Where(u => u.userName == obj.userName
                                      && u.password == obj.password)
                                                 select u)
                                         .ToList<Registration>();



                    if (obj != null)
                    {

                        obj.token = GenerateKey(obj.userName);
                        obj.password = "";
                        return Ok(obj);
                    }

                    else
                    {
                        ModelState.AddModelError("", "Invalid User Name or Password");
                        return View(obj);
                    }
                }
            }
            else
            {
                return View(obj);
            }
           
        }
        //public IActionResult Index(string userName, string password)
        //{
        //    PatientDAL dal = new PatientDAL();
        //    var model = from r in dal.Registrations
        //                orderby r.userName
        //                where r.userName == userName || userName == null ||
        //                userName == ""
        //                where r.password == password || password == null || password == ""
        //                select r;
        //    return Ok(model);

        //}



        //public IActionResult Post([FromBody] LoginModel obj)
        //{
        //    if ((obj.userName == "Avanti") && (obj.password == "ABC@00"))
        //    {
        //        obj.token = GenerateKey(obj.userName);
        //        obj.password = "";
        //        return Ok(obj);
        //    }
        //    else
        //    {
        //        return StatusCode(401, "Not a valid User ");
        //    }
        //}




        // PUT api/<SecurityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SecurityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

       
    
}
