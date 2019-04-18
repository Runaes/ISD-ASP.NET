using OMS.Models;
using System.Data.Entity;

namespace OMS.DAL
{
	public class StoreContext : DbContext
	{
		public StoreContext()
		{
		}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
		public DbSet<Stock> Stock { get; set; }

	}
}
