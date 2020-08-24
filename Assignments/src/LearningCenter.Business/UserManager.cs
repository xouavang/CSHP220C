using LearningCenter.Business.Interfaces;
using LearningCenter.Business.Models;
using LearningCenter.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Business
{
    public class UserManager : IUserManger
    {
        private readonly IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserModel LogIn(string email, string password)
        {
            var user = userRepository.Login(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.Id, Email = user.Email, IsAdmin = user.IsAdmin };
        }

        public UserModel Register(string email, string password)
        {
            var user = userRepository.Register(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.Id, Email = user.Email, IsAdmin = user.IsAdmin };
        }
    }
}
