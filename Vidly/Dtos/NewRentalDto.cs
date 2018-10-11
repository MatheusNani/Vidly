using System.Collections.Generic;

namespace Vidly.Dtos
{
	public class NewRentalDto
	{
		public NewRentalDto()
		{
			MoviesIds = new List<int>();
		}


		public int CustomerIds { get; set; }
		public List<int> MoviesIds { get; set; }


	}
}
