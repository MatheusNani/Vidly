using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Discount
	{
		public int Id { get; set; }
		public Customers Customer { get; set; }
		public double DiscountRate { get; set; }
		public DateTime CreateDate { get; set; }

	}
}
