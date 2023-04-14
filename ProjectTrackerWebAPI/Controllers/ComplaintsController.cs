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
    public class ComplaintsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ComplaintsController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Complaints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Complaint>>> GetComplaint()
        {
          if (_context.Complaint == null)
          {
              return NotFound();
          }
            return await _context.Complaint.ToListAsync();
        }

        // GET: api/Complaints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Complaint>> GetComplaint(Guid id)
        {
          if (_context.Complaint == null)
          {
              return NotFound();
          }
            var complaint = await _context.Complaint.FindAsync(id);

            if (complaint == null)
            {
                return NotFound();
            }

            return complaint;
        }

        // PUT: api/Complaints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComplaint(Guid id, ComplaintsDTO complaintDTO)
        {
             
            try
            {
                var UpdateItem = await _context.Complaint.FindAsync(id);
                if (UpdateItem != null)
                {
                    UpdateItem.ModifiedOn = DateTime.Now;
                    UpdateItem.Title = complaintDTO.Title;
                    UpdateItem.Description = complaintDTO.Description;
                    UpdateItem.DepartmentId = complaintDTO.DepartmentId;
                    UpdateItem.IsResolved = complaintDTO.IsResolved;
                    _context.Complaint.Update(UpdateItem);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplaintExists(id))
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

        // POST: api/Complaints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Complaint>> PostComplaint(ComplaintsDTO complaintDTO)
        {
          if (_context.Complaint == null)
          {
              return Problem("Entity set 'APIDbContext.Complaint'  is null.");
          }
            var complaint = new Complaint()
            {
                Id = Guid.NewGuid(),
                Title = complaintDTO.Title,
                Description = complaintDTO.Description,
                DepartmentId = complaintDTO.DepartmentId,
                IsResolved = complaintDTO.IsResolved,
                CreatedOn = DateTime.Now,
                IsActive = true
                 
            };
            _context.Complaint.Add(complaint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComplaint", new { id = complaint.Id }, complaint);
        }

        // DELETE: api/Complaints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(Guid id)
        {
            if (_context.Complaint == null)
            {
                return NotFound();
            }
            var complaint = await _context.Complaint.FindAsync(id);
            if (complaint == null)
            {
                return NotFound();
            }

            _context.Complaint.Remove(complaint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComplaintExists(Guid id)
        {
            return (_context.Complaint?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
