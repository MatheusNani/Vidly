using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class MoviesFormViewModel
	{
		public IEnumerable<GenreTypes> GenreTypes { get; set; }
		public Movies Movies { get; set; }
	}
}
