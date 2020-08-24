using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LearningCenter.Website.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}