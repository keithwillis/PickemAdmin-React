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
    public class ConferencesController : ControllerBase
    {
        private readonly PickemContext _context;

        public ConferencesController(PickemContext context)
        {
            _context = context;
        }

        // GET: api/Conferences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conference>>> GetConferences()
        {
            return await _context.Conferences.ToListAsync();
        }

        // GET: api/Conferences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conference>> GetConference(int id)
        {
            var conference = await _context.Conferences.FindAsync(id);

            if (conference == null)
            {
                return NotFound();
            }

            return conference;
        }

        // PUT: api/Conferences/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConference(int id, Conference conference)
        {
            if (id != conference.Id)
            {
                return BadRequest();
            }

            _context.Entry(conference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConferenceExists(id))
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

        // POST: api/Conferences
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Conference>> PostConference(Conference conference)
        {
            _context.Conferences.Add(conference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConference", new { id = conference.Id }, conference);
        }

        // DELETE: api/Conferences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Conference>> DeleteConference(int id)
        {
            var conference = await _context.Conferences.FindAsync(id);
            if (conference == null)
            {
                return NotFound();
            }

            _context.Conferences.Remove(conference);
            await _context.SaveChangesAsync();

            return conference;
        }

        private bool ConferenceExists(int id)
        {
            return _context.Conferences.Any(e => e.Id == id);
        }
    }
}
