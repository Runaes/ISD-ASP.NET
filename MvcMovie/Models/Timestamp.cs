using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
	public class Timestamp
	{
		public int ID { get; set; }
		public int AccountID { get; set; }
		public DateTime LoginTime { get; set; }
	}
}
