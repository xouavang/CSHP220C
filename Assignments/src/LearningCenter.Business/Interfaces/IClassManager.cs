using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Business.Models;

namespace LearningCenter.Business.Interfaces
{
    public interface IClassManager
    {
        ClassModel[] Classes { get; }
        ClassModel Class(int classId);
    }
}
