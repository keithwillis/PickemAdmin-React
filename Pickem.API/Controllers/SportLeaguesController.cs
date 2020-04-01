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
    public class SportLeaguesController : ControllerBase
    {
        private readonly PickemContext _context;

        public SportLeaguesController(PickemContext context)
        {
            _context = context;
        }

        // GET: api/SportLeagues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportLeague>>> GetSportLeagues()
        {
            return await _context.SportLeagues.Include(l => l.Conferences).ToListAsync();
        }

        // GET: api/SportLeagues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SportLeague>> GetSportLeague(int id)
        {
            var sportLeague = await _context.SportLeagues.FindAsync(id);

            if (sportLeague == null)
            {
                return NotFound();
            }

            return sportLeague;
        }

        // PUT: api/SportLeagues/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSportLeague(int id, SportLeague sportLeague)
        {
            if (id != sportLeague.Id)
            {
                return BadRequest();
            }

            _context.Entry(sportLeague).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportLeagueExists(id))
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

        // POST: api/SportLeagues
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SportLeague>> PostSportLeague(SportLeague sportLeague)
        {
            if (validateSportLeague(sportLeague))
            {
                _context.SportLeagues.Add(sportLeague);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSportLeague", new { id = sportLeague.Id }, sportLeague);
            }
            else
            {
                return new BadRequestObjectResult("Sport League Name is Required");
            }
        }

        // DELETE: api/SportLeagues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SportLeague>> DeleteSportLeague(int id)
        {
            var sportLeague = await _context.SportLeagues.FindAsync(id);
            if (sportLeague == null)
            {
                return NotFound();
            }

            _context.SportLeagues.Remove(sportLeague);
            await _context.SaveChangesAsync();

            return sportLeague;
        }

        private bool validateSportLeague(SportLeague sl)
        {
            if (sl.Name == string.Empty)
            {
                return false;
            }
            return true;
        }

        private bool SportLeagueExists(int id)
        {
            return _context.SportLeagues.Any(e => e.Id == id);
        }
    }
}
