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

        // Filters movies according to the filters chosen by the user.
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

            // Gets the list of genres.
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

        // Sorts movies into the order desired by the user.
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

            // Get list of genres.
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

        // View for adding a movie to the catalogue.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adds a movie to the catalogue. 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Stock,Director,Description,ImageURL")] Movie movie)
        {
            // PERFORMS SERVER-SIDE VALIDATION - confirmed working with javascript disabled on client.
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // View for editing a movie in the catalogue.
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

        // POST: Edits a movie in a catalogue.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Stock,Director,Description,ImageURL")] Movie movie)
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

        // Returns view to delete a movie.
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

        // POST: Deletes a movie from the catalogue.
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
        // Shows the details of a movie.
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
        // Shows the details of a movie as well as a link to the edit page when accessed with admin credentials.
        public async Task<IActionResult> ManageDetails(int? id)
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
