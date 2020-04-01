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
    public class GameGroupsController : ControllerBase
    {
        private readonly PickemContext _context;

        public GameGroupsController(PickemContext context)
        {
            _context = context;
        }

        // GET: api/GameGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameGroup>>> GetGameGroups()
        {
            return await _context.GameGroups.ToListAsync();
        }

        // GET: api/GameGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameGroup>> GetGameGroup(int id)
        {
            var gameGroup = await _context.GameGroups.FindAsync(id);

            if (gameGroup == null)
            {
                return NotFound();
            }

            return gameGroup;
        }

        // PUT: api/GameGroups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameGroup(int id, GameGroup gameGroup)
        {
            if (id != gameGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameGroupExists(id))
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

        // POST: api/GameGroups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GameGroup>> PostGameGroup(GameGroup gameGroup)
        {
            _context.GameGroups.Add(gameGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameGroup", new { id = gameGroup.Id }, gameGroup);
        }

        // DELETE: api/GameGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameGroup>> DeleteGameGroup(int id)
        {
            var gameGroup = await _context.GameGroups.FindAsync(id);
            if (gameGroup == null)
            {
                return NotFound();
            }

            _context.GameGroups.Remove(gameGroup);
            await _context.SaveChangesAsync();

            return gameGroup;
        }

        private bool GameGroupExists(int id)
        {
            return _context.GameGroups.Any(e => e.Id == id);
        }
    }
}
