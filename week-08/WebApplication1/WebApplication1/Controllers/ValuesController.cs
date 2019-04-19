using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly WebApplication1Context _context;

        public ValuesController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: api/Values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> GetValue()
        {
            return await _context.Values.ToListAsync();
        }

        // GET: api/Values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> GetValue(Guid id)
        {
            var value = await _context.Values.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            return value;
        }

        // PUT: api/Values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValue(Guid id, Value value)
        {
            if (id != value.ID)
            {
                return BadRequest();
            }

            _context.Entry(value).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValueExists(id))
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

        // POST: api/Values
        [HttpPost]
        public async Task<ActionResult<Value>> PostValue(Value value)
        {
            _context.Values.Add(value);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValue", new { id = value.ID }, value);
        }

        // DELETE: api/Values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Value>> DeleteValue(Guid id)
        {
            var value = await _context.Values.FindAsync(id);
            if (value == null)
            {
                return NotFound();
            }

            _context.Values.Remove(value);
            await _context.SaveChangesAsync();

            return value;
        }

        private bool ValueExists(Guid id)
        {
            return _context.Values.Any(e => e.ID == id);
        }
    }
}
