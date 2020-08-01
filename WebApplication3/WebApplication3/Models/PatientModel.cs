using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Patient
    {
       
       [Required]
       public int id { get; set; }

        [Required]
        [RegularExpression("^[a-z]{1,10}$")] 
        public string name { get; set; }

       //to many relationship
        public List<problem> problems { get; set; } //pural

       
    }

    public class problem // singular
    {
        public int id { get; set; }

        [Required]
        public string problemDescription { get; set; }

        public Patient patient { get; set; }
    }
}
