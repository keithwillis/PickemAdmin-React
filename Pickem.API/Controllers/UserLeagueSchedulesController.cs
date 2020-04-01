using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pickem.Data;
using Pickem.Domain;

namespace Pickem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLeagueSchedulesController : ControllerBase
    {
        private readonly PickemContext _context;

        public UserLeagueSchedulesController(PickemContext context)
        {
            _context = context;
        }

        // GET: api/UserLeagueSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLeagueSchedule>>> GetUserLeagueSchedules()
        {
            return await _context.UserLeagueSchedules.ToListAsync();
        }

        // GET: api/UserLeagueSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLeagueSchedule>> GetUserLeagueSchedule(int id)
        {
            var userLeagueSchedule = await _context.UserLeagueSchedules.FindAsync(id);

            if (userLeagueSchedule == null)
            {
                return NotFound();
            }

            return userLeagueSchedule;
        }

        // PUT: api/UserLeagueSchedules/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLeagueSchedule(int id, UserLeagueSchedule userLeagueSchedule)
        {
            if (id != userLeagueSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(userLeagueSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLeagueScheduleExists(id))
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

        // POST: api/UserLeagueSchedules
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserLeagueSchedule>> PostUserLeagueSchedule(UserLeagueSchedule userLeagueSchedule)
        {
            _context.UserLeagueSchedules.Add(userLeagueSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLeagueSchedule", new { id = userLeagueSchedule.Id }, userLeagueSchedule);
        }

        // DELETE: api/UserLeagueSchedules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserLeagueSchedule>> DeleteUserLeagueSchedule(int id)
        {
            var userLeagueSchedule = await _context.UserLeagueSchedules.FindAsync(id);
            if (userLeagueSchedule == null)
            {
                return NotFound();
            }

            _context.UserLeagueSchedules.Remove(userLeagueSchedule);
            await _context.SaveChangesAsync();

            return userLeagueSchedule;
        }

        private bool UserLeagueScheduleExists(int id)
        {
            return _context.UserLeagueSchedules.Any(e => e.Id == id);
        }
    }
}
