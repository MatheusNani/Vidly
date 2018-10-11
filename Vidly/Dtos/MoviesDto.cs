using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
	public class MoviesDto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter customer's name.")]
		[StringLength(100)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter Release Date.")]
		public DateTime? ReleasedDate { get; set; }

		public DateTime AddedDate { get; set; }

		[Range(1, 20)]
		[Required(ErrorMessage = "Please enter Number in stock.")]
		public int NumberInStock { get; set; }

		public byte GenreTypesId { get; set; }

		public GenreTypesDto GenreTypes { get; set; }

		public MoviesDto()
		{
			AddedDate = DateTime.Now;
		}
	}
}
