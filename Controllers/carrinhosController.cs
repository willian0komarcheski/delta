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
    public class carrinhosController : ControllerBase
    {
        private readonly lojaDbContext _context;

        public carrinhosController(lojaDbContext context)
        {
            _context = context;
        }

        // GET: api/carrinhos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<carrinho>>> Getcarrinhos()
        {
          if (_context.carrinhos == null)
          {
              return NotFound();
          }
            return await _context.carrinhos.ToListAsync();
        }

        // GET: api/carrinhos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<carrinho>> Getcarrinho(int id)
        {
          if (_context.carrinhos == null)
          {
              return NotFound();
          }
            var carrinho = await _context.carrinhos.FindAsync(id);

            if (carrinho == null)
            {
                return NotFound();
            }

            return carrinho;
        }

        // PUT: api/carrinhos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcarrinho(int id, carrinho carrinho)
        {
            if (id != carrinho.carrinhoId)
            {
                return BadRequest();
            }

            _context.Entry(carrinho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!carrinhoExists(id))
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

        // POST: api/carrinhos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<carrinho>> Postcarrinho(carrinho carrinho)
        {
          if (_context.carrinhos == null)
          {
              return Problem("Entity set 'lojaDbContext.carrinhos'  is null.");
          }
            _context.carrinhos.Add(carrinho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcarrinho", new { id = carrinho.carrinhoId }, carrinho);
        }

        // DELETE: api/carrinhos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecarrinho(int id)
        {
            if (_context.carrinhos == null)
            {
                return NotFound();
            }
            var carrinho = await _context.carrinhos.FindAsync(id);
            if (carrinho == null)
            {
                return NotFound();
            }

            _context.carrinhos.Remove(carrinho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool carrinhoExists(int id)
        {
            return (_context.carrinhos?.Any(e => e.carrinhoId == id)).GetValueOrDefault();
        }
    }
}
