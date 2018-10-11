using System.Web.Mvc;
using Vidly.Models;
using System.Linq;

namespace Vidly.Controllers
{
	public class RentalsController : Controller
	{
		public ActionResult New()
		{
			return View("NewRentalForm");
		}

		public ActionResult ListRentals()
		{
			return View();
		}
	}
}
