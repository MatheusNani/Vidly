using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
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
			// Here we are setting only the Admin user, the one that has CanManageMovie access to 
			//Edit, Delete and add a New Movie.
			if (User.IsInRole(RoleName.CanManageMovie))
				return View("List");

			return View("ReadOnlyList");
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

		[Authorize(Roles = RoleName.CanManageMovie)]
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

		[Authorize(Roles = RoleName.CanManageMovie)]
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

		[Authorize(Roles = RoleName.CanManageMovie)]
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
