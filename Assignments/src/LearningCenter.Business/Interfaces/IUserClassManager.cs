using LearningCenter.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Business.Interfaces
{
    public interface IUserClassManager
    {
        UserClassModel Add(int userId, int classId);
        UserClassModel[] Classes(int userId);
    }
}
