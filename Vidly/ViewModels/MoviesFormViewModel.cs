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


		public string Title
		{
			get
			{
				if (Movies != null && Movies.Id != 0)
				{
					return "Edit Movie";
				}

				return "New Movie";
			}
		}

	}
}
