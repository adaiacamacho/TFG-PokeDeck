using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_PokeDeck.Entidades;

namespace Backend_PokeDeck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartasController : ControllerBase
    {
        private readonly PokedeckContext _context;

        public CartasController(PokedeckContext context)
        {
            _context = context;
        }

        // GET: api/Cartas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carta>>> GetCartas()
        {
            return await _context.Cartas.ToListAsync();
        }

        // GET: api/Cartas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carta>> GetCarta(string id)
        {
            var carta = await _context.Cartas.FindAsync(id);

            if (carta == null)
            {
                return NotFound();
            }

            return carta;
        }

        // GET: api/Cartas/por-baraja/5
        [HttpGet("por-baraja/{idBaraja}")]
        public async Task<ActionResult<List<string>>> GetCartasPorBaraja(int idBaraja)
        {
            var idsCartas = await _context.Cartas.Where(cb => cb.IdBaraja == idBaraja).Select(cb => cb.Id).ToListAsync();

            return idsCartas ?? new List<string>();
        }



        // PUT: api/Cartas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarta(string id, Carta carta)
        {
            if (!id.Equals(carta.Id))
            {
                return BadRequest();
            }

            _context.Entry(carta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaExists(id))
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

        // POST: api/Cartas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carta>> PostCarta(Carta carta)
        {
            try
            {
                _context.Cartas.Add(carta);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCarta", new { id = carta.Id }, carta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ ERROR AL INSERTAR CARTA:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }



        // DELETE: api/Cartas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarta(string id)
        {
            var carta = await _context.Cartas.FindAsync(id);
            if (carta == null)
            {
                return NotFound();
            }

            _context.Cartas.Remove(carta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartaExists(string id)
        {
            return _context.Cartas.Any(e => e.Id.Equals(id));
        }
    }
}
