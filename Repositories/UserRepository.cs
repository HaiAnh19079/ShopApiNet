using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApiNet.models;

namespace ShopApiNet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLDBContext _context;
        public UserRepository(MySQLDBContext context)
        {
            _context = context;
        }

        public async Task<UserModel> Add(UserModel user)
        {
            
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public Task<IActionResult> Authenticate(string UserName, string Password)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            var listUser = await _context.Users.ToListAsync();
            return listUser;
        }

        public async Task<UserModel> GetById(Guid id)
        {
            var userById = await _context.Users.FindAsync(id);
            
            return userById;
        }

        public async Task<UserModel> GetByNameAndPassword(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
            return user;
        }
    }
}