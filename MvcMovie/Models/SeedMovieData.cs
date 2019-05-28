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
                        Price = 5.99M,
                        Stock = 12,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },

                    new Movie
                    {
                        Title = "Star Wars - Episode II: Attack of the Clones",
                        ReleaseDate = DateTime.Parse("2002-5-16"),
                        Genre = "Science Fiction",
                        Price = 5.99M,
                        Stock = 5,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 6.99M,
                        Stock = 4,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },

                    new Movie
                    {
                        Title = "Garfield: The Movie",
                        ReleaseDate = DateTime.Parse("2004-6-11"),
                        Genre = "Comedy",
                        Price = 3.99M,
                        Stock = 9,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "The Godfather",
                        ReleaseDate = DateTime.Parse("1972-6-11"),
                        Genre = "Crime",
                        Price = 5.49M,
                        Stock = 4,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "The Shawshank Redemption",
                        ReleaseDate = DateTime.Parse("1994-5-16"),
                        Genre = "Drama",
                        Price = 9.99M,
                        Stock = 16,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Schindler's List",
                        ReleaseDate = DateTime.Parse("1993-2-21"),
                        Genre = "Biography",
                        Price = 2.49M,
                        Stock = 6,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Raging Bull",
                        ReleaseDate = DateTime.Parse("1980-12-13"),
                        Genre = "Drama",
                        Price = 7.49M,
                        Stock = 3,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Casablanca",
                        ReleaseDate = DateTime.Parse("1942-6-14"),
                        Genre = "Drama",
                        Price = 5.49M,
                        Stock = 5,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Citizen Kane",
                        ReleaseDate = DateTime.Parse("1941-4-18"),
                        Genre = "Drama",
                        Price = 16.99M,
                        Stock = 4,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Gone with the Wind",
                        ReleaseDate = DateTime.Parse("1939-7-09"),
                        Genre = "Drama",
                        Price = 11.99M,
                        Stock = 7,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "The Wizard of Oz",
                        ReleaseDate = DateTime.Parse("1939-6-13"),
                        Genre = "Adventure",
                        Price = 3.99M,
                        Stock = 3,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Lawrence of Arabia",
                        ReleaseDate = DateTime.Parse("1962-8-18"),
                        Genre = "Adventure",
                        Price = 8.49M,
                        Stock = 13,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Singin' in the Rain",
                        ReleaseDate = DateTime.Parse("1952-6-25"),
                        Genre = "Comedy",
                        Price = 9.49M,
                        Stock = 11,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "It's a Wonderful Life",
                        ReleaseDate = DateTime.Parse("1946-3-11"),
                        Genre = "Drama",
                        Price = 5.99M,
                        Stock = 1,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Some Like It Hot",
                        ReleaseDate = DateTime.Parse("1959-11-01"),
                        Genre = "Comedy",
                        Price = 3.99M,
                        Stock = 8,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Ben-Hur",
                        ReleaseDate = DateTime.Parse("1959-3-26"),
                        Genre = "Adventure",
                        Price = 7.99M,
                        Stock = 15,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Amadeus",
                        ReleaseDate = DateTime.Parse("1984-8-10"),
                        Genre = "Biography",
                        Price = 14.99M,
                        Stock = 5,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "The Lord of the Rings: The Return of the King",
                        ReleaseDate = DateTime.Parse("2003-7-18"),
                        Genre = "Adventure",
                        Price = 12.99M,
                        Stock = 6,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Gladiator",
                        ReleaseDate = DateTime.Parse("2000-4-05"),
                        Genre = "Action",
                        Price = 3.49M,
                        Stock = 4,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "Raiders of the Lost Ark",
                        ReleaseDate = DateTime.Parse("1981-1-03"),
                        Genre = "Action",
                        Price = 5.49M,
                        Stock = 13,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "Science Fiction"
                    },
                    new Movie
                    {
                        Title = "To Kill a Mockingbird",
                        ReleaseDate = DateTime.Parse("1962-3-11"),
                        Genre = "Crime",
                        Price = 8.99M,
                        Stock = 7,
                        Director = "Science Fiction",
                        Description = "Science Fiction",
                        ImageURL = "https://snworksceo.imgix.net/tdl/25189dfc-e7c3-4e3e-930e-def95e9aec35.sized-1000x1000.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}