using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendServices.DTO;
using BackendServices.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackendServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private IAccount _accountRepository;
        public AccountsController(IAccount accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountCreateDto accountCreateDto)
        {
            try
            {
                await _accountRepository.Register(accountCreateDto.username, accountCreateDto.password);
                return Ok($"User {accountCreateDto.username} created successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountCreateDto accountCreateDto)
        {
            try
            {
                var token = await _accountRepository.Login(accountCreateDto.username,
                    accountCreateDto.password);
                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest("Invalid credentials");
                }
                return Ok(token);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}