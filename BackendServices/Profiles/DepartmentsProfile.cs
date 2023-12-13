using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendServices.DTO;
using BackendServices.Models;

namespace BackendServices.Profiles
{
    public class DepartmentsProfile : Profile
    {
        public DepartmentsProfile()
        {
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentUpdateDto, Department>();
            CreateMap<Department, DepartmentDto>();
        }
    }
}