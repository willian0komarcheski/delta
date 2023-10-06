using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoLoginController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoLoginController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoLogin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoLogin>>> GetTodoLogin()
        {
          if (_context.TodoLogin == null)
          {
              return NotFound();
          }
            return await _context.TodoLogin.ToListAsync();
        }

        // GET: api/TodoLogin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoLogin>> GetTodoLogin(long id)
        {
          if (_context.TodoLogin == null)
          {
              return NotFound();
          }
            var todoLogin = await _context.TodoLogin.FindAsync(id);

            if (todoLogin == null)
            {
                return NotFound();
            }

            return todoLogin;
        }

        // PUT: api/TodoLogin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoLogin(long id, TodoLogin todoLogin)
        {
            if (id != todoLogin.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoLoginExists(id))
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

        // POST: api/TodoLogin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoLogin>> PostTodoLogin(TodoLogin todoLogin)
        {
          if (_context.TodoLogin == null)
          {
              return Problem("Entity set 'TodoContext.TodoLogin'  is null.");
          }
            _context.TodoLogin.Add(todoLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoLogin", new { id = todoLogin.Id }, todoLogin);
        }

        // DELETE: api/TodoLogin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoLogin(long id)
        {
            if (_context.TodoLogin == null)
            {
                return NotFound();
            }
            var todoLogin = await _context.TodoLogin.FindAsync(id);
            if (todoLogin == null)
            {
                return NotFound();
            }

            _context.TodoLogin.Remove(todoLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoLoginExists(long id)
        {
            return (_context.TodoLogin?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
