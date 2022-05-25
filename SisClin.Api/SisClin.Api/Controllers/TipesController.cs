using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisClin.Domain;
using SisClin.Infra.Data;

namespace SisClin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipesController : ControllerBase
    {
        private readonly DbSisClin _context;

        public TipesController(DbSisClin context)
        {
            _context = context;
        }

        // GET: api/Tipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipe>>> GetTipes()
        {
            return await _context.Tipes.ToListAsync();
        }

        // GET: api/Tipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipe>> GetTipe(int id)
        {
            var tipe = await _context.Tipes.FindAsync(id);

            if (tipe == null)
            {
                return NotFound();
            }

            return tipe;
        }

        // PUT: api/Tipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipe(int id, Tipe tipe)
        {
            if (id != tipe.TipeId)
            {
                return BadRequest();
            }

            _context.Entry(tipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipeExists(id))
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

        // POST: api/Tipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tipe>> PostTipe(Tipe tipe)
        {
            _context.Tipes.Add(tipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipe", new { id = tipe.TipeId }, tipe);
        }

        // DELETE: api/Tipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipe(int id)
        {
            var tipe = await _context.Tipes.FindAsync(id);
            if (tipe == null)
            {
                return NotFound();
            }

            _context.Tipes.Remove(tipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipeExists(int id)
        {
            return _context.Tipes.Any(e => e.TipeId == id);
        }
    }
}
