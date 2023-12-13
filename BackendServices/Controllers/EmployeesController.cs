using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendServices.DTO;
using BackendServices.Models;
using BackendServices.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackendServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployee employeeRepository,
        IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            var employees = await _employeeRepository.GetEmployeesWithDepartments();
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeeDtos;
        }
    }
}