using AutoMapper;
using Bookie.Dtos;
using Bookie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<BookDto, Book>()
                .ForMember(b => b.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Loan, OldLoanDto>();
        }
    }
}