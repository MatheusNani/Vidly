using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

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

		public ActionResult New()
		{
			var genre = _context.GenreTypes.ToList();
			var viewModel = new MoviesFormViewModel
			{
				GenreTypes = genre
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(Movies movies)
		{
			if (movies.Id == 0)
			{
				movies.AddedDate = DateTime.Now;
				_context.Movies.Add(movies);
			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Movies");
		}
	}
}
