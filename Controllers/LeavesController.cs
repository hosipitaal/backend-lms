using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models;
using NuGet.Protocol;

namespace LeaveManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeavesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Leaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leaves>>> GetAllLeaves()
        {
            return await _context.AllLeaves.ToListAsync();
        }

        //[Route("/applyleave")]
        [HttpGet("getleavedetails/{id}")]
        public async Task<ActionResult<IEnumerable<Leaves>>> GetEmpLeaves(int id)
        {
            var leaves = await _context.AllLeaves.Where(u => u.emp_id == id).ToListAsync();
            return Ok(leaves);

        }

        // GET: api/Leaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Leaves>> GetLeaves(int id)
        {
            var leaves = await _context.AllLeaves.FindAsync(id);

            if (leaves == null)
            {
                return NotFound();
            }

            return leaves;
        }

        // PUT: api/Leaves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaves(int id, Leaves leaves)
        {
            if (id != leaves.leave_id)
            {
                return BadRequest();
            }

            _context.Entry(leaves).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeavesExists(id))
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

        // POST: api/Leaves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Leaves>> PostLeaves(Leaves leaves)
        {
            _context.AllLeaves.Add(leaves);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaves", new { id = leaves.leave_id }, leaves);
        }   

        // DELETE: api/Leaves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaves(int id)
        {
            var leaves = await _context.AllLeaves.FindAsync(id);
            if (leaves == null)
            {
                return NotFound();
            }

            _context.AllLeaves.Remove(leaves);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeavesExists(int id)
        {
            return _context.AllLeaves.Any(e => e.leave_id == id);
        }
    }
}
