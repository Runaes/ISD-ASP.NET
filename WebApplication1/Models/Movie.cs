using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models
{
	public class Movie
	{
		public int Movie_ID { get; set; }
		public int Price { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Stock> Stock { get; set; }
		public virtual ICollection<Genre> Genres { get; set; }
	}
}
