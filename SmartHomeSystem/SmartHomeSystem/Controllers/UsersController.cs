using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHomeSystem.Context;
using SmartHomeSystem.Models;
using SmartHomeSystem.RequestModels;
using System.Net;
using System.Net.Http;

namespace SmartHomeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SmartHomeSystemDBContext _context;

        public UsersController(SmartHomeSystemDBContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        [Route("Register")]
        public  void Register(UserRequestModel user_req)
        {
            User user = new User();
            try
            {
                user = _context.Users.Where(usr => (usr.Username == user_req.Username &&
                usr.Password == user_req.Password)).ToList()[0];
            }catch(Exception e)
            {
                 user = null;
            }
            if(user == null)
            {
                User new_user = new User();
                new_user.Username = user_req.Username;
                new_user.Password = user_req.Password;
                new_user.Email = user_req.Email;
                new_user.FirstName = user_req.FirstName;
                new_user.LastName = user_req.LastName;

                _context.Users.Add(new_user);
                _context.SaveChanges();
            }
            
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserRequestModel user_req)
        {
            User user = new User();
            try
            {
                user = _context.Users.Where(usr => (usr.Username == user_req.Username &&
                usr.Password == user_req.Password)).ToList()[0];
            }
            catch (Exception e)
            {
                user = null;
            }
            if (user != null)
            {
                return  Ok();
            }
            return NotFound();
        }


        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
