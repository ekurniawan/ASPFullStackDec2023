using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendServices.Models;

namespace BackendServices.Repository
{
    public interface IDepartment : ICrud<Department>
    {
        Task<IEnumerable<Department>> GetByName(string name);
    }
}