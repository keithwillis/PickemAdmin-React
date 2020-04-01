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
    public class UserLeagueScheduleUserPicksController : ControllerBase
    {
        private readonly PickemContext _context;

        public UserLeagueScheduleUserPicksController(PickemContext context)
        {
            _context = context;
        }

        // GET: api/UserLeagueScheduleUserPicks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLeagueScheduleUserPicks>>> GetUserLeagueScheduleUserPicks()
        {
            return await _context.UserLeagueScheduleUserPicks.ToListAsync();
        }

        // GET: api/UserLeagueScheduleUserPicks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLeagueScheduleUserPicks>> GetUserLeagueScheduleUserPicks(int id)
        {
            var userLeagueScheduleUserPicks = await _context.UserLeagueScheduleUserPicks.FindAsync(id);

            if (userLeagueScheduleUserPicks == null)
            {
                return NotFound();
            }

            return userLeagueScheduleUserPicks;
        }

        // PUT: api/UserLeagueScheduleUserPicks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLeagueScheduleUserPicks(int id, UserLeagueScheduleUserPicks userLeagueScheduleUserPicks)
        {
            if (id != userLeagueScheduleUserPicks.Id)
            {
                return BadRequest();
            }

            _context.Entry(userLeagueScheduleUserPicks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLeagueScheduleUserPicksExists(id))
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

        // POST: api/UserLeagueScheduleUserPicks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserLeagueScheduleUserPicks>> PostUserLeagueScheduleUserPicks(UserLeagueScheduleUserPicks userLeagueScheduleUserPicks)
        {
            _context.UserLeagueScheduleUserPicks.Add(userLeagueScheduleUserPicks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLeagueScheduleUserPicks", new { id = userLeagueScheduleUserPicks.Id }, userLeagueScheduleUserPicks);
        }

        // DELETE: api/UserLeagueScheduleUserPicks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserLeagueScheduleUserPicks>> DeleteUserLeagueScheduleUserPicks(int id)
        {
            var userLeagueScheduleUserPicks = await _context.UserLeagueScheduleUserPicks.FindAsync(id);
            if (userLeagueScheduleUserPicks == null)
            {
                return NotFound();
            }

            _context.UserLeagueScheduleUserPicks.Remove(userLeagueScheduleUserPicks);
            await _context.SaveChangesAsync();

            return userLeagueScheduleUserPicks;
        }

        private bool UserLeagueScheduleUserPicksExists(int id)
        {
            return _context.UserLeagueScheduleUserPicks.Any(e => e.Id == id);
        }
    }
}
