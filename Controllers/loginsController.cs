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
    public class loginsController : ControllerBase
    {
        private readonly lojaDbContext _context;

        public loginsController(lojaDbContext context)
        {
            _context = context;
        }

        // GET: api/logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<login>>> Getlogins()
        {
          if (_context.logins == null)
          {
              return NotFound();
          }
            return await _context.logins.ToListAsync();
        }

        // GET: api/logins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<login>> Getlogin(int id)
        {
          if (_context.logins == null)
          {
              return NotFound();
          }
            var login = await _context.logins.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return login;
        }

        // PUT: api/logins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlogin(int id, login login)
        {
            if (id != login.loginId)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!loginExists(id))
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

        // POST: api/logins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<login>> Postlogin(login login)
        {
          if (_context.logins == null)
          {
              return Problem("Entity set 'lojaDbContext.logins'  is null.");
          }
            _context.logins.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlogin", new { id = login.loginId }, login);
        }

        // DELETE: api/logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelogin(int id)
        {
            if (_context.logins == null)
            {
                return NotFound();
            }
            var login = await _context.logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.logins.Remove(login);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool loginExists(int id)
        {
            return (_context.logins?.Any(e => e.loginId == id)).GetValueOrDefault();
        }
    }
}
