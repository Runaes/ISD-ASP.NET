using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string movieGenre, string searchString, string currentGenre)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "TitleAscending" ? "TitleDescending" : "TitleAscending";
            ViewBag.DateSortParm = sortOrder == "ReleaseDateAscending" ? "ReleaseDateDescending" : "ReleaseDateAscending";
            ViewBag.GenreSortParm = sortOrder == "GenreAscending" ? "GenreDescending" : "GenreAscending";
            ViewBag.PriceSortParm = sortOrder == "PriceAscending" ? "PriceDescending" : "PriceAscending";
            ViewBag.StockSortParm = sortOrder == "StockAscending" ? "StockDescending" : "StockAscending";

            if (searchString == null)
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (movieGenre == null)
            {
                movieGenre = currentGenre;
            }

            ViewBag.CurrentGenre = movieGenre;

            var movies = from s in _context.Movie
                         select s;

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from s in _context.Movie
                                            orderby s.Genre
                                            select s.Genre;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(s => s.Genre == movieGenre);
            }

            switch (sortOrder)
            {
                case "TitleAscending":
                    movies = movies.OrderBy(s => s.Title);
                    break;
                case "TitleDescending":
                    movies = movies.OrderByDescending(s => s.Title);
                    break;
                case "ReleaseDateAscending":
                    movies = movies.OrderBy(s => s.ReleaseDate);
                    break;
                case "ReleaseDateDescending":
                    movies = movies.OrderByDescending(s => s.ReleaseDate);
                    break;
                case "GenreAscending":
                    movies = movies.OrderBy(s => s.Genre);
                    break;
                case "GenreDescending":
                    movies = movies.OrderByDescending(s => s.Genre);
                    break;
                case "PriceAscending":
                    movies = movies.OrderBy(s => s.Price);
                    break;
                case "PriceDescending":
                    movies = movies.OrderByDescending(s => s.Price);
                    break;
                case "StockAscending":
                    movies = movies.OrderBy(s => s.Stock);
                    break;
                case "StockDescending":
                    movies = movies.OrderByDescending(s => s.Stock);
                    break;
                default:
                    movies = movies.OrderByDescending(s => s.Title);
                    break;
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        public async Task<IActionResult> BrowseCollection(string sortOrder, string currentFilter, string movieGenre, string searchString, string currentGenre)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "TitleAscending" ? "TitleDescending" : "TitleAscending";
            ViewBag.DateSortParm = sortOrder == "ReleaseDateAscending" ? "ReleaseDateDescending" : "ReleaseDateAscending";
            ViewBag.GenreSortParm = sortOrder == "GenreAscending" ? "GenreDescending" : "GenreAscending";
            ViewBag.PriceSortParm = sortOrder == "PriceAscending" ? "PriceDescending" : "PriceAscending";
            ViewBag.StockSortParm = sortOrder == "StockAscending" ? "StockDescending" : "StockAscending";

            if (searchString == null)
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (movieGenre == null)
            {
                movieGenre = currentGenre;
            }

            ViewBag.CurrentGenre = movieGenre;

            var movies = from s in _context.Movie
                         select s;

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from s in _context.Movie
                                            orderby s.Genre
                                            select s.Genre;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(s => s.Genre == movieGenre);
            }

            switch (sortOrder)
            {
                case "TitleAscending":
                    movies = movies.OrderBy(s => s.Title);
                    break;
                case "TitleDescending":
                    movies = movies.OrderByDescending(s => s.Title);
                    break;
                case "ReleaseDateAscending":
                    movies = movies.OrderBy(s => s.ReleaseDate);
                    break;
                case "ReleaseDateDescending":
                    movies = movies.OrderByDescending(s => s.ReleaseDate);
                    break;
                case "GenreAscending":
                    movies = movies.OrderBy(s => s.Genre);
                    break;
                case "GenreDescending":
                    movies = movies.OrderByDescending(s => s.Genre);
                    break;
                case "PriceAscending":
                    movies = movies.OrderBy(s => s.Price);
                    break;
                case "PriceDescending":
                    movies = movies.OrderByDescending(s => s.Price);
                    break;
                case "StockAscending":
                    movies = movies.OrderBy(s => s.Stock);
                    break;
                case "StockDescending":
                    movies = movies.OrderByDescending(s => s.Stock);
                    break;
                default:
                    movies = movies.OrderByDescending(s => s.Title);
                    break;
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Stock")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Stock")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}
