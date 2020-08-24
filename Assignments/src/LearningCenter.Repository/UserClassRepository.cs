using LearningCenter.ClassDatabase;
using LearningCenter.Repository.Interfaces;
using LearningCenter.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Repository
{
    public class UserClassRepository : IUserClassRepository
    {
        public UserClassModel Add(int userId, int classId)
        {
            var newClass = DatabaseAccessor.Instance.Classes.First(t => t.ClassId == classId);
            var user = DatabaseAccessor.Instance.Users.First(t => t.UserId == userId);
            
            user.Classes.Add(newClass);

            DatabaseAccessor.Instance.SaveChanges();

            return new LearningCenter.Repository.Models.UserClassModel { ClassId = newClass.ClassId, UserId = user.UserId };
        }

        public UserClassModel[] Classes(int userId)
        {
            var studentClasses = DatabaseAccessor.Instance.Users
                .First(t => t.UserId == userId)
                .Classes
                .Select(t => new UserClassModel { ClassId = t.ClassId, UserId = t.Users.First().UserId })
                .ToArray();

            return studentClasses;
        }
    }
}
