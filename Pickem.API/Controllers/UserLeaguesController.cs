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
    public class UserLeaguesController : ControllerBase
    {
        private readonly PickemContext _context;

        public UserLeaguesController(PickemContext context)
        {
            _context = context;
        }

        // GET: api/UserLeagues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLeague>>> GetUserLeagues()
        {
            return await _context.UserLeagues.ToListAsync();
        }

        // GET: api/UserLeagues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLeague>> GetUserLeague(int id)
        {
            var userLeague = await _context.UserLeagues.FindAsync(id);

            if (userLeague == null)
            {
                return NotFound();
            }

            return userLeague;
        }

        // PUT: api/UserLeagues/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLeague(int id, UserLeague userLeague)
        {
            if (id != userLeague.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userLeague).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLeagueExists(id))
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

        // POST: api/UserLeagues
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserLeague>> PostUserLeague(UserLeague userLeague)
        {
            _context.UserLeagues.Add(userLeague);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserLeagueExists(userLeague.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserLeague", new { id = userLeague.UserId }, userLeague);
        }

        // DELETE: api/UserLeagues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserLeague>> DeleteUserLeague(int id)
        {
            var userLeague = await _context.UserLeagues.FindAsync(id);
            if (userLeague == null)
            {
                return NotFound();
            }

            _context.UserLeagues.Remove(userLeague);
            await _context.SaveChangesAsync();

            return userLeague;
        }

        private bool UserLeagueExists(int id)
        {
            return _context.UserLeagues.Any(e => e.UserId == id);
        }
    }
}
