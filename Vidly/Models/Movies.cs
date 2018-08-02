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

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[Required]
		public DateTime ReleasedDate { get; set; }

		[Required]
		public DateTime AddedDate { get; set; }

		[Required]
		public int NumberInStock { get; set; }

		public GenreTypes GenreTypes { get; set; }
		public byte GenreId { get; set; }
	}
}
