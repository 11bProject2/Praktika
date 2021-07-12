using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using KatalogFilmi;

namespace WebAppFilmi.Controllers
{
    public class MoviesActorsController : Controller
    {
        private readonly MovieContext _context;

        public MoviesActorsController(MovieContext context)
        {
            _context = context;
        }

        // GET: MoviesActors
        public async Task<IActionResult> Index()
        {
            var movieContext = _context.MoviesActors.Include(m => m.Actor).Include(m => m.Movie);
            return View(await movieContext.ToListAsync());
        }

        // GET: MoviesActors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MoviesActors
                .Include(m => m.Actor)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieActor == null)
            {
                return NotFound();
            }

            return View(movieActor);
        }

        // GET: MoviesActors/Create
        public IActionResult Create()
        {
            ViewData["ActorId"] = new SelectList(_context.Persons, "Id", "FirstName");
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            return View();
        }

        // POST: MoviesActors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,ActorId")] MovieActor movieActor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieActor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorId"] = new SelectList(_context.Persons, "Id", "FirstName", movieActor.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieActor.MovieId);
            return View(movieActor);
        }

        // GET: MoviesActors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MoviesActors.FindAsync(id);
            if (movieActor == null)
            {
                return NotFound();
            }
            ViewData["ActorId"] = new SelectList(_context.Persons, "Id", "FirstName", movieActor.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieActor.MovieId);
            return View(movieActor);
        }

        // POST: MoviesActors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,ActorId")] MovieActor movieActor)
        {
            if (id != movieActor.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieActor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieActorExists(movieActor.MovieId))
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
            ViewData["ActorId"] = new SelectList(_context.Persons, "Id", "FirstName", movieActor.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieActor.MovieId);
            return View(movieActor);
        }

        // GET: MoviesActors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MoviesActors
                .Include(m => m.Actor)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieActor == null)
            {
                return NotFound();
            }

            return View(movieActor);
        }

        // POST: MoviesActors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieActor = await _context.MoviesActors.FindAsync(id);
            _context.MoviesActors.Remove(movieActor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieActorExists(int id)
        {
            return _context.MoviesActors.Any(e => e.MovieId == id);
        }
    }
}
