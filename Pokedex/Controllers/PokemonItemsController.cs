using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedexApi.Models;

namespace Pokedex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonItemsController : ControllerBase
    {
        private readonly PokedexContext _context;

        public PokemonItemsController(PokedexContext context)
        {
            _context = context;
        }

        // GET: api/PokemonItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonItem>>> GetPokemonItems()
        {
            return await _context.PokemonItems.ToListAsync();
        }

        // GET: api/PokemonItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonItem>> GetPokemonItem(long id)
        {
            var PokemonItem = await _context.PokemonItems.FindAsync(id);

            if (PokemonItem == null)
            {
                return NotFound();
            }

            return PokemonItem;
        }

        // GET: api/PokemonItems/type/Flame
        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<PokemonItem>>> GetPokemonByType(string type)
        {
            var PokemonItem = await _context.PokemonItems.Where(i => i.Type == type).ToListAsync();

            if (PokemonItem == null)
            {
                return NotFound();
            }

            return PokemonItem;
        }

        // GET: api/PokemonItems/name/Charizard
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<PokemonItem>>> GetPokemonByName(string name)
        {
            var PokemonItem = await _context.PokemonItems.Where(i => i.Name == name).ToListAsync();

            if (PokemonItem == null)
            {
                return NotFound();
            }

            return PokemonItem;
        }

        // PUT: api/PokemonItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokemonItem(long id, PokemonItem PokemonItem)
        {
            if (id != PokemonItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(PokemonItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonItemExists(id))
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

        // POST: api/PokemonItems
        [HttpPost]
        public async Task<ActionResult<PokemonItem>> PostPokemonItem(PokemonItem PokemonItem)
        {
            _context.PokemonItems.Add(PokemonItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPokemonItem), new { id = PokemonItem.Id }, PokemonItem);
        }

        // DELETE: api/PokemonItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemonItem(long id)
        {
            var PokemonItem = await _context.PokemonItems.FindAsync(id);
            if (PokemonItem == null)
            {
                return NotFound();
            }

            _context.PokemonItems.Remove(PokemonItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PokemonItemExists(long id)
        {
            return _context.PokemonItems.Any(e => e.Id == id);
        }
    }
}
