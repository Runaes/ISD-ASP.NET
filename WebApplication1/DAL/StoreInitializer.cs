using OMS.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace OMS.DAL
{
	public class StoreInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
	{
		protected override void Seed(StoreContext context)
		{
			context.Movies.AddRange(new List<Movie>
			{
				new Movie { Name = "Egg Shen and the 6 Demon Bag", Price = 30, Genres = new List<Genre>() },
				new Movie { Name = "The Monster and the Ape", Price = 15, Genres = new List<Genre>() },
				new Movie { Name = "The Brain the wouldn't die", Price = 5, Genres = new List<Genre>() },
			});
			context.SaveChanges();

			context.Genres.AddRange(new List<Genre>
			{
				new Genre { Name = "Horror" },
				new Genre { Name = "Action" },
				new Genre { Name = "Thriller" },
			});
			context.SaveChanges();
		}
	}
}
