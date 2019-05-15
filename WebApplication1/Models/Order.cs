using System;

namespace OMS.Models
{
	public class Order
	{
		public int Order_ID { get; set; }
		public int Customer_ID { get; set; }
		public DateTime OrderDate { get; set; }
	}
}