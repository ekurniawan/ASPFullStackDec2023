using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BackendServices.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BackendServices.Repository
{
    public class AccountRepository : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AccountRepository(UserManager<IdentityUser> userManager,
        IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }
        public async Task<string> Login(string username, string password)
        {
            var currUser = await _userManager.FindByNameAsync(username);
            var userResult = await _userManager.CheckPasswordAsync(currUser, password);
            if (!userResult)
            {
                throw new Exception($"Invalid credentials for user {username}");
            }

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, username));
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task Register(string username, string password)
        {
            try
            {
                var newUser = new IdentityUser
                {
                    UserName = username,
                    Email = username
                };
                var result = await _userManager.CreateAsync(newUser, password);
                if (!result.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var error in result.Errors)
                    {
                        sb.AppendLine(error.Description);
                    }
                    throw new Exception(sb.ToString());
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}