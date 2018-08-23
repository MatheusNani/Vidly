using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Vidly.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Customers> Customers { get; set; }
		public DbSet<Movies> Movies { get; set; }
		public DbSet<MembershipType> MembershipType { get; set; }
		public DbSet<GenreTypes> GenreTypes { get; set; }

		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}
