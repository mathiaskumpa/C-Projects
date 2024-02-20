using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDB.Data;
using MovieDB.Models;

namespace MovieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public VotesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/Votes
        [HttpGet]
        public async Task<IActionResult> GetVotes()
        {
            var votes = await _context.Votes.ToListAsync();
            return Ok(votes);
        }

        // GET: api/Votes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVote(int id)
        {
            var vote = await _context.Votes.FindAsync(id);

            if (vote == null)
            {
                return NotFound();
            }

            return Ok(vote);
        }

        // POST: api/Votes
        [HttpPost]
        public async Task<IActionResult> PostVote(Vote model)
        {
            // Check if the user has already voted for the movie
            var existingVote = await _context.Votes
                .Where(v => v.MovieID == model.MovieID && v.UserID == model.UserID)
                .FirstOrDefaultAsync();

            if (existingVote != null)
            {
                return BadRequest("User has already voted for this movie.");
            }

            // Proceed with adding the new vote
            var newVote = new Vote
            {
                MovieID = model.MovieID,
                UserID = model.UserID,
                RatingValue = model.RatingValue,
                VoteDate = DateTime.Now
            };

            // Add new vote to the database
            _context.Votes.Add(newVote);
            await _context.SaveChangesAsync();

            return Ok("Vote successfully cast.");
        }

        // PUT: api/Votes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVote(int id, Vote model)
        {
            if (id != model.VoteID)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteExists(id))
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

        // DELETE: api/Votes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVote(int id)
        {
            var vote = await _context.Votes.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }

            _context.Votes.Remove(vote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoteExists(int id)
        {
            return _context.Votes.Any(e => e.VoteID == id);
        }
    }
}
