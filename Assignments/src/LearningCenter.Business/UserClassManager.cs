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
    public class UserClassManager : IUserClassManager
    {
        private readonly IUserClassRepository userClassRepository;
        private readonly IClassRepository classRepository;

        public UserClassManager(IUserClassRepository userClassRepository, IClassRepository classRepository)
        {
            this.userClassRepository = userClassRepository;
            this.classRepository = classRepository;
        }

        public UserClassModel Add(int userId, int classId)
        {
            var newclass = userClassRepository.Add(userId, classId);

            return new LearningCenter.Business.Models.UserClassModel { ClassId = newclass.ClassId, UserId = newclass.UserId };
        }

        public UserClassModel[] Classes(int userId)
        {
            var classes = userClassRepository.Classes(userId)
                .Select(t =>
                {
                    var enrolledClass = classRepository.Class(t.ClassId);

                    return new UserClassModel
                    {
                        ClassId = t.ClassId,
                        ClassDescription = enrolledClass.Description,
                        ClassName = enrolledClass.Name,
                        ClassPrice = enrolledClass.Price
                    };
                })
                .ToArray();

            return classes;
        }
    }
}
