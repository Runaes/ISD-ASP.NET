using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
	public class Timestamp
	{
		[ForeignKey("Account")]
		public int ID { get; set; }
		public DateTime LoginTime { get; set; }
	}
}
