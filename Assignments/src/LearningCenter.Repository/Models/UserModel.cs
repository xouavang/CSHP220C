using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Repository.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
