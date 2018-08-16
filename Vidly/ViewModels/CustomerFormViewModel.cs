using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class CustomerFormViewModel
	{
		// Here I could use either List or IEnumerable, the difference is that
		// In the view we are not going to use any of the methods of List, such as Add,Remove.
		// So It's just better to use IENumerable
		public IEnumerable<MembershipType> MembershipTypes { get; set; }
		public Customers Customers { get; set; }

		public string Title
		{
			get
			{
				if (Customers != null && Customers.Id != 0)
				{
					return "Edit Customer";
				}

				return "New Customer";
			}
		}

	}
}
