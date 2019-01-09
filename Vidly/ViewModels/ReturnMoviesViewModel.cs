using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class ReturnMoviesViewModel
	{
		public Customers customer { get; set; }
		public Movies movies { get; set; }				
	}
}
