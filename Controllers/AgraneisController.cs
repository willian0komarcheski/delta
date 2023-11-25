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
    public class AgraneisController : ControllerBase
    {
        private readonly lojaDbContext _context;

        public AgraneisController(lojaDbContext context)
        {
            _context = context;
        }

        // GET: api/Agraneis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agranel>>> GetAgraneis()
        {
          if (_context.Agraneis == null)
          {
              return NotFound();
          }
            return await _context.Agraneis.ToListAsync();
        }

        // GET: api/Agraneis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agranel>> GetAgranel(int id)
        {
          if (_context.Agraneis == null)
          {
              return NotFound();
          }
            var agranel = await _context.Agraneis.FindAsync(id);

            if (agranel == null)
            {
                return NotFound();
            }

            return agranel;
        }

        // PUT: api/Agraneis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgranel(int id, Agranel agranel)
        {
            if (id != agranel.AgranelId)
            {
                return BadRequest();
            }

            _context.Entry(agranel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgranelExists(id))
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

        // POST: api/Agraneis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agranel>> PostAgranel(Agranel agranel)
        {
          if (_context.Agraneis == null)
          {
              return Problem("Entity set 'lojaDbContext.Agraneis'  is null.");
          }
            _context.Agraneis.Add(agranel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgranel", new { id = agranel.AgranelId }, agranel);
        }

        // DELETE: api/Agraneis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgranel(int id)
        {
            if (_context.Agraneis == null)
            {
                return NotFound();
            }
            var agranel = await _context.Agraneis.FindAsync(id);
            if (agranel == null)
            {
                return NotFound();
            }

            _context.Agraneis.Remove(agranel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgranelExists(int id)
        {
            return (_context.Agraneis?.Any(e => e.AgranelId == id)).GetValueOrDefault();
        }
    }
}
