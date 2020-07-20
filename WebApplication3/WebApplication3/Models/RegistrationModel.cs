using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Registration 

    {
        

        [Key]
        [Required, MaxLength(256)]
        [RegularExpression("^[A-Z][a-z]{1,10}$")]
        public string userName { get; set; }

        [Required, DataType(DataType.Password)]
        public string password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
    }
}
