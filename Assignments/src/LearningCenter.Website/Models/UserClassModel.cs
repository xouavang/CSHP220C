using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningCenter.Website.Models
{
    public class UserClassModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
    }
}