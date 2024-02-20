using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models.DTO;
using MovieApp.Models.Domain;

namespace MovieApp.Controllers
{
    public class VotesController : Controller
    {
        private readonly DatabaseContext _context;

        public VotesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Votes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Votes.ToListAsync());
        }

        // GET: Votes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Votes
                .FirstOrDefaultAsync(m => m.VoteId == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // GET: Votes/Create
        public IActionResult Create(long movieId)
        {
            // Check if movieId is valid
            var movie = _context.Movies.Find(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            // Set MovieId in the ViewData to be used in the Create.cshtml
            ViewData["MovieId"] = movieId;

            // You can also pass the username to the view if needed
            ViewData["Username"] = User.Identity.Name;

            // Create a SelectList for the UserId dropdown
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoteId,UserId,MovieId,Rating,VoteDate")] Vote vote)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Ensure that vote.UserId is correctly set
                    vote.UserId = vote.UserId; // Set the UserId from the form or use the current user's Id

                    // Check if the user has already voted for the movie
                    var existingVote = await _context.Votes
                        .FirstOrDefaultAsync(v => v.MovieId == vote.MovieId && v.UserId == vote.UserId);

                    if (existingVote != null)
                    {
                        // User has already voted for this movie, handle accordingly (e.g., display an error message)
                        ModelState.AddModelError("MovieId", "You have already voted for this movie.");
                        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", vote.UserId);
                        return View(vote);
                    }

                    // Set the MovieId from the ViewData
                    if (ViewData["MovieId"] != null)
                    {
                        vote.MovieId = (long)ViewData["MovieId"];
                    }

                    _context.Add(vote);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", vote.UserId);
                return View(vote);
            }
            catch (Exception ex)
            {
                // Log or print the exception details
                Console.WriteLine("Error:", ex.Message);
                throw; // Re-throw the exception to see the full stack trace in the console
            }
        }

        // GET: Votes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Votes.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", vote.UserId);
            return View(vote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoteId,UserId,MovieId,Rating,VoteDate")] Vote vote)
        {
            if (id != vote.VoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoteExists(vote.VoteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", vote.UserId);
            return View(vote);
        }

        // GET: Votes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Votes
                .FirstOrDefaultAsync(m => m.VoteId == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vote = await _context.Votes.FindAsync(id);
            if (vote != null)
            {
                _context.Votes.Remove(vote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoteExists(int id)
        {
            return _context.Votes.Any(e => e.VoteId == id);
        }
    }
}
