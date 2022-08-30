using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Intern_Management_System.CRUDContext;
using Intern_Management_System.Models;

namespace Intern_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class designationDetailsController : ControllerBase
    {
        private readonly CRUD _context;

        public designationDetailsController(CRUD context)
        {
            _context = context;
        }

        // GET: api/designationDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<designationDetails>>> GetDesignationDetail()
        {
            return await _context.DesignationDetail.ToListAsync();
        }

        // GET: api/designationDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<designationDetails>> GetdesignationDetails(int id)
        {
            var designationDetails = await _context.DesignationDetail.FindAsync(id);

            if (designationDetails == null)
            {
                return NotFound();
            }

            return designationDetails;
        }

        // PUT: api/designationDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdesignationDetails(int id, designationDetails designationDetails)
        {
            if (id != designationDetails.DesignationId)
            {
                return BadRequest();
            }

            _context.Entry(designationDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!designationDetailsExists(id))
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

        // POST: api/designationDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<designationDetails>> PostdesignationDetails(designationDetails designationDetails)
        {
            _context.DesignationDetail.Add(designationDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetdesignationDetails", new { id = designationDetails.DesignationId }, designationDetails);
        }

        // DELETE: api/designationDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletedesignationDetails(int id)
        {
            var designationDetails = await _context.DesignationDetail.FindAsync(id);
            if (designationDetails == null)
            {
                return NotFound();
            }

            _context.DesignationDetail.Remove(designationDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool designationDetailsExists(int id)
        {
            return _context.DesignationDetail.Any(e => e.DesignationId == id);
        }
    }
}
