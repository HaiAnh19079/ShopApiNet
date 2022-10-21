using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApiNet.models;

namespace ShopApiNet.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAll();
        Task<UserModel> GetById(Guid id);
        Task<UserModel> GetByNameAndPassword(string userName, string password);

        Task<UserModel> Add(UserModel user);
        Task<IActionResult> Authenticate(string UserName, string Password);
    }
}