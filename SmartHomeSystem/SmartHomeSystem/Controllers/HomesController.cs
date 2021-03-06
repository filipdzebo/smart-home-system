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

namespace SmartHomeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private readonly SmartHomeSystemDBContext _context;

        public HomesController(SmartHomeSystemDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("HomeCreate")]
        public async void Create(HomeRequestModel home_req)
        {
            Home new_home = new Home();
            new_home.Name = home_req.Name;
            new_home.Address = home_req.Address;
            new_home.Owner = null;
            new_home.DevicesInHome = null;
            new_home.UserHome = null;
            try
            {
                _context.Homes.Add(new_home);
                _context.SaveChanges();
            }
            catch { }
            
        }

        [HttpPost]
        [Route("HomesOfUser")]
        public async Task<ActionResult<Home>> GetHomesOfUser(int id)
        {
            List<Home> logged_user_homes = _context.Homes.Where(home => home.Owner.UserId == id).ToList();
            return  Ok(logged_user_homes);
        }

        // GET: api/Homes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Home>>> GetHomes()
        {
            return await _context.Homes.ToListAsync();
        }

        // GET: api/Homes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Home>> GetHome(int id)
        {
            var home = await _context.Homes.FindAsync(id);

            if (home == null)
            {
                return NotFound();
            }

            return home;
        }

        // PUT: api/Homes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHome(int id, Home home)
        {
            if (id != home.HomeId)
            {
                return BadRequest();
            }

            _context.Entry(home).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeExists(id))
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

        // POST: api/Homes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Home>> PostHome(Home home)
        {
            _context.Homes.Add(home);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHome", new { id = home.HomeId }, home);
        }

        // DELETE: api/Homes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Home>> DeleteHome(int id)
        {
            var home = await _context.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }

            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();

            return home;
        }

        private bool HomeExists(int id)
        {
            return _context.Homes.Any(e => e.HomeId == id);
        }
    }
}
