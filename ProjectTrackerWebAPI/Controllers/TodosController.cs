using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerWebAPI.Data;
using ProjectTrackerWebAPI.Models;
using ProjectTrackerWebAPI.Models.DTO;

namespace ProjectTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly APIDbContext _context;

        public TodosController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todos>>> Gettodos()
        {
          if (_context.todos == null)
          {
              return NotFound();
          }
            return await _context.todos.ToListAsync();
        }

        // GET: api/Todos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todos>> GetTodos(Guid id)
        {
          if (_context.todos == null)
          {
              return NotFound();
          }
            var todos = await _context.todos.FindAsync(id);

            if (todos == null)
            {
                return NotFound();
            }

            return todos;
        }

        // PUT: api/Todos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodos(Guid id,TodoDTO todoDTO)
        {
            try
            {
                var UpdateItem = await _context.todos.FindAsync(id);
                if (UpdateItem != null)
                {
                    UpdateItem.ModifiedOn = DateTime.Now;
                    UpdateItem.Description = todoDTO.Description;
                    UpdateItem.IsRead = todoDTO.IsRead;
                    _context.todos.Update(UpdateItem);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodosExists(id))
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

        // POST: api/Todos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Todos>> PostTodos(TodoDTO todoDTO)
        {
          if (_context.todos == null)
          {
              return Problem("Entity set 'APIDbContext.todos'  is null.");
          }
            var todos = new Todos
            {
                Id = Guid.NewGuid(),
                Description = todoDTO.Description,
                IsRead = todoDTO.IsRead,
                CreatedOn = DateTime.Now,
                IsActive = true
            };
            _context.todos.Add(todos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodos", new { id = todos.Id }, todos);
        }

        // DELETE: api/Todos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodos(Guid id)
        {
            if (_context.todos == null)
            {
                return NotFound();
            }
            var todos = await _context.todos.FindAsync(id);
            if (todos == null)
            {
                return NotFound();
            }

            _context.todos.Remove(todos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodosExists(Guid id)
        {
            return (_context.todos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
