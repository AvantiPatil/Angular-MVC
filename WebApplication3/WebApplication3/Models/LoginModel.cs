using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class LoginModel
    {
        [Key]
        [Required]
        [RegularExpression("^[A-Z][a-z]{1,10}$")]
        [Compare("userName")]
        public string userName { get; set; }
        [Compare("password")]
        public string password { get; set; }
        public string token { get; set; }
    }
}
