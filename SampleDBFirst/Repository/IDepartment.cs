using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleDBFirst.Models;

namespace SampleDBFirst.Repository
{
    public interface IDepartment
    {
        IEnumerable<Department> GetAll();
        void Delete(int id);
    }
}