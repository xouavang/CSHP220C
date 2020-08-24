using LearningCenter.Repository.Interfaces;
using LearningCenter.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserModel Login(string email, string password)
        {
            var user = DatabaseAccessor.Instance.Users.FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower() && t.UserPassword == password);
            if (user == null)
            {
                return null;
            }
            return new UserModel { Id = user.UserId, Email = user.UserEmail, IsAdmin = user.UserIsAdmin };
        }

        public UserModel Register(string email, string password)
        {
            var user = DatabaseAccessor.Instance.Users.Add(new LearningCenter.ClassDatabase.User { UserEmail = email, UserPassword = password });

            DatabaseAccessor.Instance.SaveChanges();

            return new UserModel { Id = user.UserId, Email = user.UserEmail, IsAdmin = user.UserIsAdmin };
        }
    }
}
