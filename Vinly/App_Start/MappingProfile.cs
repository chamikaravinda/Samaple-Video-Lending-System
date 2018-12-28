using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vinly.Dtos;
using Vinly.Models;

namespace Vinly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MoviesDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MoviesDto, Movie>()
               .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}