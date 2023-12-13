using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleDBFirst.Models;

namespace SampleDBFirst.Repository
{
    public class DepartmentRepository : IDepartment
    {
        private readonly SampleEfdbContext _context;

        public DepartmentRepository(SampleEfdbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"exec DeleteDepartmentSP {id}");
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Department> GetAll()
        {
            var departments = _context.Departments.FromSqlRaw(
                "exec [dbo].[MyDepartments]").ToList();
            return departments;
        }


    }
}