using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopApiNet.models;
using ShopApiNet.Repositories;

namespace ShopApiNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        // private readonly MySQLDBContext _context;
        public UserController _user;
        public IUserRepository _userRepository;

        public TokenController(IConfiguration config,IUserRepository userRepository)
        {
            _configuration = config;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateToken(string userName, string password)
        {
            if (userName != null && password != null)
            {
                UserModel user = await GetUser(userName, password);

                if (user != null)
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("FullName", user.FullName),
                    new Claim("UserName", user.UserName),
                    new Claim("Email", user.Email),
                    new Claim(ClaimTypes.Role, user.Role),

                };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<UserModel> GetUser(string userName, string password)
        {
            return await _userRepository.GetByNameAndPassword(userName, password);
        }


    }
}