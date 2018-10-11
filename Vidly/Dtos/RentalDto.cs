using System;

namespace Vidly.Dtos
{
	public class RentalDto
	{
		public CustomersDto Customers { get; set; }
		public MoviesDto Movies { get; set; }
		public DateTime RentedDate { get; set; }
		public DateTime ReturnedDate { get; set; }

		public RentalDto()
		{
			RentedDate = DateTime.Now;
		}
	}
}
