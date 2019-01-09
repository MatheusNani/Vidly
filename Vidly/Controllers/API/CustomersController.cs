using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
	public class CustomersController : ApiController
	{
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		//GET /API/CUSTOMERS
		[HttpGet]
		public IHttpActionResult GetCustomers(string query = null)
		{
			var customerQuery = _context
										.Customers
										.Include(c => c.MembershipType);

			if (!String.IsNullOrWhiteSpace(query))
				customerQuery = customerQuery
											.Where(c => c.Name.Contains(query) && 
											c.Isdelinquent == false);

			var customerDtos = customerQuery
				.ToList()
				.Select(Mapper.Map<Customers, CustomersDto>);

			return Ok(customerDtos);
		}

		//GET /API/CUSTOMERS/ID
		[HttpGet]
		public IHttpActionResult GetCustomer(int Id)
		{
			var customer = _context
									.Customers
									.Include(c => c.MembershipType)
									.SingleOrDefault(c => c.Id == Id);
			//var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

			if (customer == null)
				return NotFound();

			return Ok(Mapper.Map<Customers, CustomersDto>(customer));
		}

		//POST /API/CUSTOMERS
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomersDto customerDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var customer = Mapper.Map<CustomersDto, Customers>(customerDto);
			_context.Customers.Add(customer);
			_context.SaveChanges();

			customerDto.Id = customer.Id;

			return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
		}

		//PUT /API/CUSTOMERS/ID
		[HttpPut]
		public void UpdateCustomer(int Id, CustomersDto customerDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			Mapper.Map(customerDto, customerInDb);

			_context.SaveChanges();
		}

		//DELETE /API/CUSTOMERS/ID
		[HttpDelete]
		public void DeleteCustomer(int Id)
		{
			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Customers.Remove(customerInDb);

			_context.SaveChanges();
		}
	}
}
