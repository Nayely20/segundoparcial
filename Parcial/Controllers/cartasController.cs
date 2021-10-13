using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial.Data;
using Parcial.Models;

namespace Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cartasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public cartasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/cartas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<carta>>> Getcarta()
        {
            return await _context.carta.ToListAsync();
        }

        // GET: api/cartas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<carta>> Getcarta(string id)
        {
            var carta = await _context.carta.FindAsync(id);

            if (carta == null)
            {
                return NotFound();
            }

            return carta;
        }

        // PUT: api/cartas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcarta(string id, carta carta)
        {
            if (id != carta.NaipeId)
            {
                return BadRequest();
            }

            _context.Entry(carta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cartaExists(id))
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

        // POST: api/cartas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<carta>> Postcarta(carta carta)
        {
            _context.carta.Add(carta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (cartaExists(carta.NaipeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getcarta", new { id = carta.NaipeId }, carta);
        }

        // DELETE: api/cartas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecarta(string id)
        {
            var carta = await _context.carta.FindAsync(id);
            if (carta == null)
            {
                return NotFound();
            }

            _context.carta.Remove(carta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool cartaExists(string id)
        {
            return _context.carta.Any(e => e.NaipeId == id);
        }
    }
}
