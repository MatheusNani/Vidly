using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

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
		[AcceptVerbs("Post")]
		[Route("api/NewRentals/ReturnMovie/{Id:int}")]
		public IHttpActionResult ReturnMovie(int Id)
		{
			var rentedMovie = _context.Rentals.Include(r => r.Movie).FirstOrDefault(r => r.Id == Id);
			var movie = _context.Movies.FirstOrDefault(m => m.Id == rentedMovie.Movie.Id);

			rentedMovie.DateReturned = DateTime.Now;
			movie.NumberAvaliable++;

			_context.SaveChanges();
			return Ok();
		}

		[HttpGet]
		public IHttpActionResult GetAllRentals()
		{
			var allRentals = _context
				.Rentals.Include(c => c.Customer.MembershipType)
				.Include(m => m.Movie.GenreTypes).Where(r => r.DateReturned == null).ToList();

			return Ok(allRentals);
		}

		[HttpGet]
		public IHttpActionResult GetRental(int Id)
		{
			var rentals = _context
				.Rentals.Include(c => c.Customer.MembershipType)
				.Include(m => m.Movie.GenreTypes)
				.Where(r => r.Customer.Id == Id).ToList();

			if (rentals == null)
				return NotFound();
			//string yourJson = Newtonsoft.Json.JsonConvert.SerializeObject(rentals);
			return Ok(rentals);
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
