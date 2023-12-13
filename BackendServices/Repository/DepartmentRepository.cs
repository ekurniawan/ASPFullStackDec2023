using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendServices.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendServices.Repository
{
    public class DepartmentRepository : IDepartment
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> Add(Department entity)
        {
            try
            {
                _context.Departments.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var department = await Get(id);
                if (department == null)
                {
                    throw new Exception("Department not found");
                }
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Department> Get(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentID == id);
            return department;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            var departments = await _context.Departments.ToListAsync();
            return departments;
        }

        public async Task<IEnumerable<Department>> GetByName(string name)
        {
            var departments = await _context.Departments
            .Where(d => d.DepartmentName.Contains(name)).ToListAsync();
            return departments;
        }

        public async Task<Department> Update(Department entity)
        {
            try
            {
                _context.Departments.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}