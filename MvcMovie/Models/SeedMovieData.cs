using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Star Wars - Episode I: The Phantom Menace",
                        ReleaseDate = DateTime.Parse("1999-5-19"),
                        Genre = "Science Fiction",
                        Price = 5.99M
                    },

                    new Movie
                    {
                        Title = "Star Wars - Episode II: Attack of the Clones",
                        ReleaseDate = DateTime.Parse("2002-5-16"),
                        Genre = "Science Fiction",
                        Price = 5.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 6.99M
                    },

                    new Movie
                    {
                        Title = "Garfield: The Movie",
                        ReleaseDate = DateTime.Parse("2004-6-11"),
                        Genre = "Comedy",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}