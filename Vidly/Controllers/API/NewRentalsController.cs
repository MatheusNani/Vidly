using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
	public class NewRentalsController : ApiController
	{
		private ApplicationDbContext _context;

		public NewRentalsController()
		{
			_context = new ApplicationDbContext();
		}

		[HttpPost]
		public IHttpActionResult CreateNewRental(NewRentalDto newRental)
		{
			var customer = _context.Customers.Single(c => c.Id == newRental.CustomerIds);
			var movies = _context.Movies.Where(m => newRental.MoviesIds.Contains(m.Id)).ToList();

			foreach (var movie in movies)
			{
				if (movie.NumberAvaliable == 0)
					return BadRequest("Movie is not available");

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
	}
}
