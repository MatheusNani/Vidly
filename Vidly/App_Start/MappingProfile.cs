using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			Mapper.CreateMap<Customers, CustomersDto>();
			Mapper.CreateMap<CustomersDto, Customers>();
			Mapper.CreateMap<MembershipType, MembershipTypeDto>();
			Mapper.CreateMap<GenreTypes, GenreTypesDto>();

			Mapper.CreateMap<Movies, MoviesDto>();
			Mapper.CreateMap<MoviesDto, Movies>();

			Mapper.CreateMap<Rental, RentalDto>();
			Mapper.CreateMap<RentalDto, Rental>();

		}
	}
}
