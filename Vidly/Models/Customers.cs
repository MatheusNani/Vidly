using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Customers
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter Customer's name.")]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }

		public MembershipType MembershipType { get; set; }

		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; }

		[Display(Name = "Date of Birth")]
		[Min18IfAMember]
		public DateTime? Birthdate { get; set; }

		public bool Isdelinquent { get; set; }
	}
}
