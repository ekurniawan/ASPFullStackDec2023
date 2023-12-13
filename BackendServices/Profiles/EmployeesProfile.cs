using AutoMapper;
using BackendServices.DTO;
using BackendServices.Models;

namespace BackendServices.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}