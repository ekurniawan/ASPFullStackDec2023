using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendServices.DTO;
using BackendServices.Models;
using BackendServices.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendServices.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private IDepartment _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartment departmentRepository,
        IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentDto>> Get()
        {
            var departments = await _departmentRepository.GetAll();
            var departmentDtos = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return departmentDtos;
        }

        [HttpGet("search")]
        public async Task<IEnumerable<DepartmentDto>> Get(string name)
        {
            var departements = await _departmentRepository.GetByName(name);
            var departmentDtos = _mapper.Map<IEnumerable<DepartmentDto>>(departements);
            return departmentDtos;
        }

        [HttpGet("{id}")]
        public async Task<DepartmentDto> Get(int id)
        {
            var department = await _departmentRepository.Get(id);
            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return departmentDto;
        }

        [HttpPost]
        public async Task<IActionResult> Post(DepartmentCreateDto departmentCreateDto)
        {
            try
            {
                var department = _mapper.Map<Department>(departmentCreateDto);
                var departmentResult = await _departmentRepository.Add(department);
                var result = _mapper.Map<DepartmentDto>(departmentResult);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(DepartmentUpdateDto departmentUpdateDto)
        {
            try
            {
                var department = _mapper.Map<Department>(departmentUpdateDto);
                var departmentResult = await _departmentRepository.Update(department);
                var result = _mapper.Map<DepartmentDto>(departmentResult);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _departmentRepository.Delete(id);
                return Ok($"Department with id {id} deleted");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}