using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
	public class DiscountController : ApiController
	{
		private ApplicationDbContext _context;

		public DiscountController()
		{
			_context = new ApplicationDbContext();
		}

		[HttpPost]
		public IHttpActionResult GetAllDiscounts()
		{
			var discountList = _context.Discount.Include(d => d.Customer).ToList();

			return Ok(discountList);
		}
	}
}
