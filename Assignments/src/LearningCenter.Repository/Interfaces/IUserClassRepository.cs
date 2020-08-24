using LearningCenter.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Repository.Interfaces
{
    public interface IUserClassRepository
    {
        UserClassModel Add(int userId, int classId);
        UserClassModel[] Classes(int userId);
    }
}
