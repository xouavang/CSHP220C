using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Repository.Interfaces;
using LearningCenter.Repository.Models;

namespace LearningCenter.Repository
{
    public class ClassRepository : IClassRepository
    {
        public ClassModel[] Classes
        {
            get
            {
                return DatabaseAccessor.Instance.Classes.Select(t => new ClassModel { Id = t.ClassId, Name = t.ClassName, Description = t.ClassDescription, Price = t.ClassPrice }).ToArray();
            }
        }

        public ClassModel Class(int classId)
        {
            var aClass = DatabaseAccessor.Instance.Classes
                .Where(t => t.ClassId == classId)
                .Select(t => new ClassModel { Id = t.ClassId, Name = t.ClassName, Description = t.ClassDescription, Price = t.ClassPrice })
                .First();

            return aClass;
        }
    }
}
