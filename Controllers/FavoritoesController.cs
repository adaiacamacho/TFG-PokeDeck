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
    public class FavoritoesController : ControllerBase
    {
        private readonly PokedeckContext _context;

        public FavoritoesController(PokedeckContext context)
        {
            _context = context;
        }

        // GET: api/Favoritoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favorito>>> GetFavoritos()
        {
            return await _context.Favoritos.ToListAsync();
        }

        // GET: api/Favoritoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorito>> GetFavorito(string id)
        {
            var favorito = await _context.Favoritos.FindAsync(id);

            if (favorito == null)
            {
                return NotFound();
            }

            return favorito;
        }

        // PUT: api/Favoritoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorito(string id, Favorito favorito)
        {
            if (id != favorito.Id)
            {
                return BadRequest();
            }

            _context.Entry(favorito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoritoExists(id))
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

        // POST: api/Favoritoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favorito>> PostFavorito(Favorito favorito)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var yaExiste = await _context.Favoritos
                .AnyAsync(f => f.Id == favorito.Id && f.IdUser == favorito.IdUser);

            if (yaExiste)
            {
                return Conflict("Este favorito ya existe.");
            }

            _context.Favoritos.Add(favorito);
            await _context.SaveChangesAsync();

            return Ok(favorito);
        }


        // DELETE: api/Favoritoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorito(string id)
        {
            var favorito = await _context.Favoritos.FindAsync(id);
            if (favorito == null)
            {
                return NotFound();
            }

            _context.Favoritos.Remove(favorito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoritoExists(string id)
        {
            return _context.Favoritos.Any(e => e.Id == id);
        }
    }
}
