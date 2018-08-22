using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace VidlyApp.Controllers

{
	public class CustomerController : Controller

	{
		// GET: Customer
		private ApplicationDbContext _context;

		public CustomerController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)

		{
			_context.Dispose();
		}

		public ViewResult Index()

		{
			var customers = _context.Customers;
			return View(customers);
		}

		public ActionResult Details(int id)

		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
			{
				return HttpNotFound();
			}
			return View(customer);
		}
	}
}
