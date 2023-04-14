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
    public class DepartmentsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public DepartmentsController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
          if (_context.Department == null)
          {
              return NotFound();
          }
             
            return await _context.Department.ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(Guid id)
        {
          if (_context.Department == null)
          {
              return NotFound();
          }
            var department = await _context.Department.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(Guid id, DepartmentDTO departmentDTO)
        {
             

            try
            {
                var UpdateDepartment = await _context.Department.FindAsync(id);
                if (UpdateDepartment != null)
                {
                    UpdateDepartment.ModifiedOn = DateTime.Now;
                    UpdateDepartment.Name = departmentDTO.Name;
                    UpdateDepartment.HODId = departmentDTO.HODId;
                    _context.Department.Update(UpdateDepartment);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(DepartmentDTO departmentDTO)
        {
          if (_context.Department == null)
          {
              return Problem("Entity set 'APIDbContext.Department'  is null.");
          }
            var Department = new Department()
            {
                Id = Guid.NewGuid(),
                Name = departmentDTO.Name,
                HODId = departmentDTO.HODId,
                CreatedOn = DateTime.Now,
                IsActive = true
            };
            _context.Department.Add(Department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = Department.Id }, Department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            if (_context.Department == null)
            {
                return NotFound();
            }
            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Department.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(Guid id)
        {
            return (_context.Department?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
