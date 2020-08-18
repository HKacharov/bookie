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
    public class ReturnsController : ApiController
    {
        private ApplicationDbContext _context;

        public ReturnsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCustomers(string query = null)
        {
            var customers = _context.Loans.Where(r =>r.DateReturned==null).Select(r => r.Customer).Distinct();
            if (customers == null)
                return NotFound();
            if (!String.IsNullOrWhiteSpace(query))
                customers = customers
                    .Where(c => c.Name.Contains(query));

            var customerDtos = customers
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        [HttpPost]
        public IHttpActionResult CreateReturn(LoanDto returns)
        {
            var customer = _context.Loans.FirstOrDefault(c => c.Customer.Id == returns.CustomerId);
            if (customer == null)
                return BadRequest("Invalid user.");

            if (returns.BookIds.Count == 0)
                return BadRequest("No Book Ids found.");

            foreach (var r in returns.BookIds)
            {
                var returning = _context.Loans.SingleOrDefault(d => d.Customer.Id == returns.CustomerId && d.Book.Id == r && d.DateReturned == null);
                var bookInDb = _context.Books.SingleOrDefault(b => b.Id == r);
                returning.DateReturned = DateTime.Now;
                bookInDb.NumberAvailable++;
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
