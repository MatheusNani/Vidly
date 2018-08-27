using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.Dtos
{
	public class NewRentalDto
	{
		public int CustomerIds { get; set; }
		public List<int> MoviesIds { get; set; }

		public NewRentalDto()
		{
			MoviesIds = new List<int>();
		}
	}
}
