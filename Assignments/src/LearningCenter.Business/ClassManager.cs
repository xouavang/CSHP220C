using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Business.Interfaces;
using LearningCenter.Business.Models;
using LearningCenter.Repository.Interfaces;

namespace LearningCenter.Business
{
    public class ClassManager : IClassManager
    {
        private readonly IClassRepository classRepository;

        public ClassManager(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public ClassModel[] Classes
        {
            get
            {
                return classRepository.Classes.Select(t => new ClassModel(t.Id, t.Name, t.Description, t.Price)).ToArray();
            }
        }

        public ClassModel Class(int classId)
        {
            var classModel = classRepository.Class(classId);
            return new ClassModel(classModel.Id, classModel.Name, classModel.Description, classModel.Price);
        }
    }
}
