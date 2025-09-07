using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_PokeDeck.Entidades;

namespace Backend_PokeDeck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarajasController : ControllerBase
    {
        private readonly PokedeckContext _context;

        public BarajasController(PokedeckContext context)
        {
            _context = context;
        }

        // GET: api/Barajas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Baraja>>> GetBarajas()
        {
            return await _context.Barajas.ToListAsync();
        }

        // GET: api/Barajas/usuario/5
        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<IEnumerable<Baraja>>> GetBarajasPorUsuario(int idUsuario)
        {
            return await _context.Barajas.Where(b => b.IdUser == idUsuario).ToListAsync();
        }

        // GET: api/Barajas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Baraja>> GetBaraja(int id)
        {
            var baraja = await _context.Barajas.FindAsync(id);

            if (baraja == null)
            {
                return NotFound();
            }

            return baraja;
        }

        // PUT: api/Barajas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaraja(int id, Baraja baraja)
        {
            if (id != baraja.Id)
            {
                return BadRequest();
            }

            _context.Entry(baraja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarajaExists(id))
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

        // POST: api/Barajas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Baraja>> PostBaraja(Baraja baraja)
        {
            _context.Barajas.Add(baraja);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BarajaExists(baraja.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBaraja", new { id = baraja.Id }, baraja);
        }

        // DELETE: api/Barajas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaraja(int id)
        {
            var baraja = await _context.Barajas.FindAsync(id);
            if (baraja == null)
            {
                return NotFound();
            }

            _context.Barajas.Remove(baraja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarajaExists(int id)
        {
            return _context.Barajas.Any(e => e.Id == id);
        }
    }
}
