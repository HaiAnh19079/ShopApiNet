// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using ShopApiNet.models;

// namespace ShopApiNet.Controllers
// {
//     [Authorize]
//     [ApiController]
//     [Route("api/employee")]
//     public class EmployeeController : ControllerBase
//     {
//         public IConfiguration _configuration;
//         private readonly MySQLDBContext _context;

//         public EmployeeController(IConfiguration config, MySQLDBContext context)
//         {
//             _configuration = config;
//             _context = context;
//         }

//         [HttpGet("{empId}")]
//         public async Task<ActionResult<EmployeeModel>> Get(int empId)
//         {
//             var employees = await _context.Employee.FirstOrDefaultAsync(e => e.EmployeeId == empId);
//             if (employees == null)
//             {
//                 return NotFound();
//             }
//             return employees;
//         }
//     }
// }