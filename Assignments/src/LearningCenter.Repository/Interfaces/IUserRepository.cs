using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Repository.Models;

namespace LearningCenter.Repository.Interfaces
{
    public interface IUserRepository
    {
        UserModel Login(string email, string password);
        UserModel Register(string email, string password);
    }
}
