using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;


namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: Movies
		public ViewResult Index()
		{
			var movies = _context.Movies.Include(m => m.GenreTypes).ToList();		
			return View(movies);
		}

		public ActionResult Details(int Id)
		{
			var movie = _context.Movies.Include(m => m.GenreTypes).SingleOrDefault(m => m.Id == Id);		
			if (movie == null)
			{
				return HttpNotFound();
			}

			return View(movie);
		}	
	}
}
