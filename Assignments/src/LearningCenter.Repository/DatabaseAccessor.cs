using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.ClassDatabase;

namespace LearningCenter.Repository
{
    public class DatabaseAccessor
    {
        private static readonly ClassDbEntities entities;

        static DatabaseAccessor()
        {
            entities = new ClassDbEntities();
            entities.Database.Connection.Open();
        }

        public static ClassDbEntities Instance => entities;
    }
}
