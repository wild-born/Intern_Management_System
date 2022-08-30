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
    public class InternDetailsController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly CRUD _context;
       

        public InternDetailsController(CRUD context)
        {
            _context = context;
        }

        // GET: api/InternDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InternDetails>>> GetInternDetails()
        {
            return await _context.InternDetails.ToListAsync();

            log.Info("Sucess");

        }

        // GET: api/InternDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InternDetails>> GetInternDetails(int id)
        {
            var internDetails = await _context.InternDetails.FindAsync(id);

            if (internDetails == null)
            {
                return NotFound();
            }

            return internDetails;
        }

        // PUT: api/InternDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInternDetails(int id, InternDetails internDetails)
        {
            if (id != internDetails.S_No)
            {
                return BadRequest();
            }

            _context.Entry(internDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternDetailsExists(id))
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

        // POST: api/InternDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InternDetails>> PostInternDetails(InternDetails internDetails)
        {
            _context.InternDetails.Add(internDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInternDetails", new { id = internDetails.S_No }, internDetails);
        }
        [HttpPost("{uname}/{pwd}")]
        public bool Login(string uname, string pwd)
        {
            var ValidUser = _context.InternDetails.FirstOrDefault(p => p.MailId == uname && p.Password == pwd);
            if (ValidUser != null)
            {
                return true;
            }

            return false;

        }
        // DELETE: api/InternDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInternDetails(int id)
        {
            var internDetails = await _context.InternDetails.FindAsync(id);
            if (internDetails == null)
            {
                return NotFound();
            }

            _context.InternDetails.Remove(internDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InternDetailsExists(int id)
        {
            return _context.InternDetails.Any(e => e.S_No == id);
        }
    }
}
