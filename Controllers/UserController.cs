using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Connection;

using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbConnection _db;
        public UserController(DbConnection db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<UserModel> AddUser(UserModel userModel)
        {
            try
            {
                var addUser = await _db.user.AddAsync(userModel);
                await _db.SaveChangesAsync();
                return addUser.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete]
        public async Task DeleteUser(int userId)
        {
            var result = await _db.user.FirstOrDefaultAsync(u => u.id == userId);
            if(result != null)
            {
                _db.user.Remove(result);
                await _db.SaveChangesAsync();
            }
        }

        [HttpGet]
        public List<UserModel> Get()
        {
            try
            {
                var user = _db.user.ToList();
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpGet("id")]
        public object GetUserDataById(int id)
        {
            try
            {

                var userData = _db.user.Where(m => m.id == id).FirstOrDefault();
                if (userData == null)
                {
                    return Ok("Data Not found.");
                }
                return Ok(userData);
            }
            catch (Exception)
            {

                throw ;
            }
        }

    }
}
