using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningCenter.Website.Models
{
    public class UserModel
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}