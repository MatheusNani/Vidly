using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		// Initializing a Db Connection
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: Customers
		public ViewResult Index()
		{
			var customers = _context.Customers.Include(c => c.MembershipType).ToList();
			return View(customers);
		}

		public ActionResult Details(int Id)
		{
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);
			if (customer == null)
			{
				return HttpNotFound();
			}
			return View(customer);
		}

		public ActionResult New()
		{
			var membershipTypes = _context.MembershipType.ToList();

			var viewModel = new CustomerFormViewModel
			{
				Customers = new Customers(),
				MembershipTypes = membershipTypes
			};
			return View("CustomerForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(CustomerFormViewModel customer) // Model binding
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors);

				var viewModel = new CustomerFormViewModel
				{
					Customers = customer.Customers,
					MembershipTypes = _context.MembershipType.ToList()
				};

				return View("CustomerForm", viewModel);
			}

			// If Id == 0 New Customer and It should save it. it's placed in the Customerform as a hiden Field.
			if (customer.Customers.Id == 0)
			{
				// Saving Data into DB
				_context.Customers.Add(customer.Customers);
			}
			else
			{
				//I could use TryUpdateModel(customerInDb), but it will update all properties
				//Or AutoMapper Library like so Mapper.Map(customer, customerInDb);

				var customerInDb = _context.Customers.Single(c => c.Id == customer.Customers.Id);

				customerInDb.Name = customer.Customers.Name;
				customerInDb.Birthdate = customer.Customers.Birthdate;
				customerInDb.MembershipTypeId = customer.Customers.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.Customers.IsSubscribedToNewsletter;
			}

			try
			{
				_context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				Console.WriteLine(e);
			}
					   
			// After saving the newCustomer or the Edited one let's redirect the user to customer List
			return RedirectToAction("Index", "Customers");
		}

		public ActionResult Edit(int Id)
		{
			// get the customer from the DB
			var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
			if (customer == null)
				return HttpNotFound();

			var viewModel = new CustomerFormViewModel
			{
				Customers = customer,
				MembershipTypes = _context.MembershipType.ToList(),
			};

			// Override the View to look for a 
			return View("CustomerForm", viewModel);
		}
	}
}
