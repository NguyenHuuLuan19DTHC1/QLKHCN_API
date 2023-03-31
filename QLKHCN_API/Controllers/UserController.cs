using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using QLKHCN_API.Data;
using System.Linq;

namespace QLKHCN_API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;
        public UserController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Login/{username},{password}")]

        public async Task<ActionResult<IEnumerable<User>>> Login(string username, string password) { 
        

            try
            {
                var result= from p in _context.Users

                            where p.username == username

                            && p.password == password

                            select p;
                if (result.Any())
                {
                    var result_user=await _context.Users.Where(a=>a.username == username).ToListAsync();
                    return result_user;
                }
                else
                {
                    return NotFound();
                }                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
