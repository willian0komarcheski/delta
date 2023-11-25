using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loja1.Data;
using loja1.Models;

namespace loja1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PereciveisController : ControllerBase
    {
        private readonly lojaDbContext _context;

        public PereciveisController(lojaDbContext context)
        {
            _context = context;
        }

        // GET: api/Pereciveis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perecivel>>> GetPereciveis()
        {
          if (_context.Pereciveis == null)
          {
              return NotFound();
          }
            return await _context.Pereciveis.ToListAsync();
        }

        // GET: api/Pereciveis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perecivel>> GetPerecivel(int id)
        {
          if (_context.Pereciveis == null)
          {
              return NotFound();
          }
            var perecivel = await _context.Pereciveis.FindAsync(id);

            if (perecivel == null)
            {
                return NotFound();
            }

            return perecivel;
        }

        // PUT: api/Pereciveis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerecivel(int id, Perecivel perecivel)
        {
            if (id != perecivel.PereciveisId)
            {
                return BadRequest();
            }

            _context.Entry(perecivel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerecivelExists(id))
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

        // POST: api/Pereciveis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Perecivel>> PostPerecivel(Perecivel perecivel)
        {
          if (_context.Pereciveis == null)
          {
              return Problem("Entity set 'lojaDbContext.Pereciveis'  is null.");
          }
            _context.Pereciveis.Add(perecivel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerecivel", new { id = perecivel.PereciveisId }, perecivel);
        }

        // DELETE: api/Pereciveis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerecivel(int id)
        {
            if (_context.Pereciveis == null)
            {
                return NotFound();
            }
            var perecivel = await _context.Pereciveis.FindAsync(id);
            if (perecivel == null)
            {
                return NotFound();
            }

            _context.Pereciveis.Remove(perecivel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerecivelExists(int id)
        {
            return (_context.Pereciveis?.Any(e => e.PereciveisId == id)).GetValueOrDefault();
        }
    }
}
