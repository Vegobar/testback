using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F20ITONK.ASPNETCore.MicroService.ClassLib.Models;

namespace backend
{
    [Route("api/[controller]")]
    [ApiController]
    public class HaandvaerkersController : ControllerBase
    {
        private readonly HaandvaerkerContext _context;

        public HaandvaerkersController(HaandvaerkerContext context)
        {
            _context = context;
            //Haandvaerker h1 = new Haandvaerker();
            //h1.HVAnsaettelsedato = DateTime.Today;
            //h1.HVEfternavn = "Hansen";
            //h1.HVFornavn = "Hans";
            //h1.HVFagomraade = "Toemrer";
            //_context.Add(h1);
            //_context.SaveChanges();
        }


        // GET: api/Haandvaerkers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Haandvaerker>>> GetHaandvaerker()
        {
            return await _context.Haandvaerker.ToListAsync();
        }

        // GET: api/Haandvaerkers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Haandvaerker>> GetHaandvaerker(int id)
        {
            var haandvaerker = await _context.Haandvaerker.FindAsync(id);

            if (haandvaerker == null)
            {
                return NotFound();
            }

            return haandvaerker;
        }

        // PUT: api/Haandvaerkers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHaandvaerker(int id, Haandvaerker haandvaerker)
        {
            if (id != haandvaerker.HaandvaerkerId)
            {
                return BadRequest();
            }

            _context.Entry(haandvaerker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HaandvaerkerExists(id))
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

        // POST: api/Haandvaerkers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Haandvaerker>> PostHaandvaerker(Haandvaerker haandvaerker)
        {
            _context.Haandvaerker.Add(haandvaerker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHaandvaerker", new { id = haandvaerker.HaandvaerkerId }, haandvaerker);
        }

        // DELETE: api/Haandvaerkers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Haandvaerker>> DeleteHaandvaerker(int id)
        {
            var haandvaerker = await _context.Haandvaerker.FindAsync(id);
            if (haandvaerker == null)
            {
                return NotFound();
            }

            _context.Haandvaerker.Remove(haandvaerker);
            await _context.SaveChangesAsync();

            return haandvaerker;
        }

        private bool HaandvaerkerExists(int id)
        {
            return _context.Haandvaerker.Any(e => e.HaandvaerkerId == id);
        }
    }
}
