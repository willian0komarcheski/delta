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
    public class RemediosController : ControllerBase
    {
        private readonly lojaDbContext _context;

        public RemediosController(lojaDbContext context)
        {
            _context = context;
        }

        // GET: api/Remedios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Remedio>>> GetRemedios()
        {
          if (_context.Remedios == null)
          {
              return NotFound();
          }
            return await _context.Remedios.ToListAsync();
        }

        // GET: api/Remedios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Remedio>> GetRemedio(int id)
        {
          if (_context.Remedios == null)
          {
              return NotFound();
          }
            var remedio = await _context.Remedios.FindAsync(id);

            if (remedio == null)
            {
                return NotFound();
            }

            return remedio;
        }

        // PUT: api/Remedios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRemedio(int id, Remedio remedio)
        {
            if (id != remedio.RemedioId)
            {
                return BadRequest();
            }

            _context.Entry(remedio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemedioExists(id))
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

        // POST: api/Remedios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Remedio>> PostRemedio(Remedio remedio)
        {
          if (_context.Remedios == null)
          {
              return Problem("Entity set 'lojaDbContext.Remedios'  is null.");
          }
            _context.Remedios.Add(remedio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRemedio", new { id = remedio.RemedioId }, remedio);
        }

        // DELETE: api/Remedios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRemedio(int id)
        {
            if (_context.Remedios == null)
            {
                return NotFound();
            }
            var remedio = await _context.Remedios.FindAsync(id);
            if (remedio == null)
            {
                return NotFound();
            }

            _context.Remedios.Remove(remedio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RemedioExists(int id)
        {
            return (_context.Remedios?.Any(e => e.RemedioId == id)).GetValueOrDefault();
        }
    }
}
