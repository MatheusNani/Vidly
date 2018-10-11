using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
	public class RentalsController : ApiController
	{
		private ApplicationDbContext _context;

		public RentalsController()
		{
			_context = new ApplicationDbContext();
		}

		[HttpPost]
		public IHttpActionResult NewRental(NewRentalDto newRental)
		{
			var customer = _context.Customers.Single(c => c.Id == newRental.CustomerIds);
			var movies = _context.Movies.Where(m => newRental.MoviesIds.Contains(m.Id)).ToList();

			foreach (var movie in movies)
			{
				if (movie.NumberAvaliable <= 0)
					return BadRequest("Movie not avaliable");

				movie.NumberAvaliable--;

				var rental = new Rental
				{
					Customer = customer,
					Movie = movie,
					DateRented = DateTime.Now
				};
				_context.Rentals.Add(rental);
			}
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet]
		public IHttpActionResult GetRentals(string query = null)
		{
			var rentalQuery = _context.Rentals.ToList();
			return Ok(rentalQuery);
		}
	}
}
