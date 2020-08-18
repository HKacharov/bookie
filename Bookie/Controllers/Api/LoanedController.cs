using AutoMapper;
using Bookie.Dtos;
using Bookie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bookie.Controllers.Api
{
    public class LoanedController : ApiController
    {
        private ApplicationDbContext _context;

        public LoanedController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetLoaned(int id)
        {
            var books = _context.Loans.Where(r => r.DateReturned == null && r.Customer.Id == id).Select(r => r.Book);

            if (books == null)
                return BadRequest("Invalid user.");


            var bookDtos = books
                .ToList()
                .Select(Mapper.Map<Book, BookDto>);

            return Ok(bookDtos);
        }
    }
}
