using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAppWithIdentity.Models;

namespace MVCAppWithIdentity.Services
{
    public interface IDepartmentServices
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> Get(int id);
        Task<Department> Add(Department entity);
        Task<Department> Update(Department entity);
        Task Delete(int id);
    }
}