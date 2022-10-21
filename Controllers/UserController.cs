using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApiNet.models;
using ShopApiNet.Repositories;

namespace ShopApiNet.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        public IConfiguration _configuration;
        public IUserRepository _userRepository;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(IConfiguration config, IUserRepository userRepository)
        {
            _configuration = config;
            _userRepository = userRepository;
        }
        // public async Task<IActionResult> Login(string userName, string password)
        // {
        //     return await _userRepository.Authenticate(userName, password);

        // }
        // [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            UserModel user = await _userRepository.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();
        }
        // [Authorize(Roles = "customer")]
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var students = await _userRepository.GetAll();
                return Ok(students);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        // [Authorize(Roles = "admin")]
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserModel user)
        {
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                user.CreatedAt = DateTime.Now;
                await _userRepository.Add(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}