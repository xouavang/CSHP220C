using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Business.Models
{
    public class UserClassModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public string ClassDescription { get; set; }
        public string ClassName { get; set; }
        public decimal ClassPrice { get; set; }
    }
}
