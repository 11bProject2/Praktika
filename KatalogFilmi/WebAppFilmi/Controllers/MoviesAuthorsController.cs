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
    public class MoviesAuthorsController : Controller
    {
        private readonly MovieContext _context;

        public MoviesAuthorsController(MovieContext context)
        {
            _context = context;
        }

        // GET: MoviesAuthors
        public async Task<IActionResult> Index()
        {
            var movieContext = _context.MoviesAuthors.Include(m => m.Author).Include(m => m.Movie);
            return View(await movieContext.ToListAsync());
        }

        // GET: MoviesAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieAuthor = await _context.MoviesAuthors
                .Include(m => m.Author)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieAuthor == null)
            {
                return NotFound();
            }

            return View(movieAuthor);
        }

        // GET: MoviesAuthors/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Persons, "Id", "FirstName");
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            return View();
        }

        // POST: MoviesAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,AuthorId")] MovieAuthor movieAuthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Persons, "Id", "FirstName", movieAuthor.AuthorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieAuthor.MovieId);
            return View(movieAuthor);
        }

        // GET: MoviesAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieAuthor = await _context.MoviesAuthors.FindAsync(id);
            if (movieAuthor == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Persons, "Id", "FirstName", movieAuthor.AuthorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieAuthor.MovieId);
            return View(movieAuthor);
        }

        // POST: MoviesAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,AuthorId")] MovieAuthor movieAuthor)
        {
            if (id != movieAuthor.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieAuthorExists(movieAuthor.MovieId))
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
            ViewData["AuthorId"] = new SelectList(_context.Persons, "Id", "FirstName", movieAuthor.AuthorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieAuthor.MovieId);
            return View(movieAuthor);
        }

        // GET: MoviesAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieAuthor = await _context.MoviesAuthors
                .Include(m => m.Author)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieAuthor == null)
            {
                return NotFound();
            }

            return View(movieAuthor);
        }

        // POST: MoviesAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieAuthor = await _context.MoviesAuthors.FindAsync(id);
            _context.MoviesAuthors.Remove(movieAuthor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieAuthorExists(int id)
        {
            return _context.MoviesAuthors.Any(e => e.MovieId == id);
        }
    }
}
