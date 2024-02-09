using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDB.Data;
using MovieDB.Models;

public class NewDirector
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Nationality { get; set; }
}

namespace MovieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public DirectorsController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/Directors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Director>>> GetDirectors()
        {
            return await _context.Directors.ToListAsync();
        }

        // GET: api/Directors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> GetDirector(int id)
        {
            var director = await _context.Directors.FindAsync(id);

            if (director == null)
            {
                return NotFound();
            }

            return director;
        }

        // POST: api/Directors
        [HttpPost]
        public async Task<ActionResult<Director>> PostDirector(NewDirector payload)
        {
            var director = new Director{
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                BirthDate = payload.BirthDate,
                Nationality = payload.Nationality,
            };
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirector", new { id = director.DirectorID }, director);
        }

        // PUT: api/Directors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirector(int id, Director director)
        {
            if (id != director.DirectorID)
            {
                return BadRequest();
            }

            _context.Entry(director).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
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

        // DELETE: api/Directors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectorExists(int id)
        {
            return _context.Directors.Any(e => e.DirectorID == id);
        }
    }
}