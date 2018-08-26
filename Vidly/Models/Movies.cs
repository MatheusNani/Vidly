using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Movies
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter customer's name.")]
		[StringLength(100)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter Release Date.")]
		[Display(Name = "Release Date")]
		public DateTime? ReleasedDate { get; set; }

		public DateTime AddedDate { get; set; }

		[Range(1, 20)]
		[Required(ErrorMessage = "Please enter Number in stock.")]
		[Display(Name = "Number in Stock")]
		public int NumberInStock { get; set; }

		public GenreTypes GenreTypes { get; set; }

		[Display(Name = "Genre Type")]
		public byte GenreTypesId { get; set; }
		
		public Movies()
		{
			AddedDate = DateTime.Now;
		}

	}
}
