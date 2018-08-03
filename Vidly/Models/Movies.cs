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


		[StringLength(100)]
		public string Name { get; set; }

		[Display(Name = "Release Date")]
		public DateTime? ReleasedDate { get; set; }

		public DateTime AddedDate { get; set; }

		[Display(Name = "Number in Stock")]
		public int NumberInStock { get; set; }

		public GenreTypes GenreTypes { get; set; }

		[Display(Name = "Genre Type")]		
		public byte GenreTypesId { get; set; }
	}
}
