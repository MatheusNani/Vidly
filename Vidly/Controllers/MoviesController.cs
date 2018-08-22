using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

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
			return View();
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
				Movies = new Movies(),
				GenreTypes = genre
			};
			return View("MoviesForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movies movies)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors);
				var viewModel = new MoviesFormViewModel
				{
					Movies = movies,
					GenreTypes = _context.GenreTypes.ToList()
				};

				return View("MoviesForm", viewModel);
			}

			if (movies.Id == 0)
			{
				//movies.AddedDate = DateTime.Now;
				_context.Movies.Add(movies);
			}
			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movies.Id);

				movieInDb.Name = movies.Name;
				movieInDb.ReleasedDate = movies.ReleasedDate;
				movieInDb.GenreTypesId = movies.GenreTypesId;
				movieInDb.NumberInStock = movies.NumberInStock;
			}

			try
			{
				_context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				Console.WriteLine(e);
			}


			return RedirectToAction("Index", "Movies");
		}

		public ActionResult Edit(int Id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

			if (movie == null)
			{
				return HttpNotFound();
			}

			var viewModel = new MoviesFormViewModel
			{
				Movies = movie,
				GenreTypes = _context.GenreTypes.ToList()
			};
			return View("MoviesForm", viewModel);
		}
	}
}
