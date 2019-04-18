using System;

namespace OMS.Models
{
	public class Order
	{
		public int Order_Id { get; set; }
		public int Customer_Id { get; set; }
		public int Customer_Name { get; set; }
		public int Product_Id { get; set; }
		public int Order_Amount { get; set; }
		public DateTime OrderDate { get; set; }
	}
}