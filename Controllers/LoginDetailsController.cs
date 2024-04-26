using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LoginDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginDetails>>> GetAllLoginDetails()
        {
            return await _context.AllLoginDetails.ToListAsync();
        }

        // GET: api/LoginDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginDetails>> GetLoginDetails(string id)
        {
            var loginDetails = await _context.AllLoginDetails.FindAsync(id);

            if (loginDetails == null)
            {
                return NotFound();
            }

            return loginDetails;
        }

        [Route("/login")]
        [HttpPost]
        public async Task<ActionResult<Employee>> Login(LoginEmployee request)
        {
            var user = await _context.AllLoginDetails.FirstOrDefaultAsync(u => u.emp_name == request.emp_name);

            if (user == null)
            {
                return NotFound();
            }
            if (user.password != request.password)
            {
                return Unauthorized("Invalid username or password");
            }

            var employee = await _context.AllEmployees.FindAsync(user.emp_id);
            if(employee== null)
            {
                return NotFound();
            }
            else
            {
                return (employee);
            }
        }


        // PUT: api/LoginDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginDetails(string id, LoginDetails loginDetails)
        {
            if (id != loginDetails.emp_name)
            {
                return BadRequest();
            }

            _context.Entry(loginDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginDetailsExists(id))
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

        // POST: api/LoginDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginDetails>> PostLoginDetails(LoginDetails loginDetails)
        {
            _context.AllLoginDetails.Add(loginDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginDetailsExists(loginDetails.emp_name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoginDetails", new { id = loginDetails.emp_name }, loginDetails);
        }







        // DELETE: api/LoginDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginDetails(string id)
        {
            var loginDetails = await _context.AllLoginDetails.FindAsync(id);
            if (loginDetails == null)
            {
                return NotFound();
            }

            _context.AllLoginDetails.Remove(loginDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginDetailsExists(string id)
        {
            return _context.AllLoginDetails.Any(e => e.emp_name == id);
        }
    }
}
