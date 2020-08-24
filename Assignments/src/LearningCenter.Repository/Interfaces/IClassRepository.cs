using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Repository.Models;

namespace LearningCenter.Repository.Interfaces
{
    public interface IClassRepository
    {
        ClassModel[] Classes { get; }
        ClassModel Class(int classId);
    }
}
